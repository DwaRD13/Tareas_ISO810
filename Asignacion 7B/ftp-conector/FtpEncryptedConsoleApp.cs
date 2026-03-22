using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using FluentFTP;

namespace ftp_conector
{
    public class FtpEncryptedConsoleApp
    {
        private const string DIVIDER = "============================================================";
        private const string SUBDIVIDER = "------------------------------------------------------------";

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            PrintHeader("FTP Encrypted Console");

            while (true)
            {
                ImprimirMenu();
                string opcion = LeerConDefault("Selecciona opcion", "1");

                try
                {
                    switch (opcion.Trim())
                    {
                        case "1":
                            EnviarArchivo();
                            EsperarEnterYLimpiar();
                            break;
                        case "2":
                            RecibirYDesencriptar();
                            EsperarEnterYLimpiar();
                            break;
                        case "3":
                            VerArchivoLocal();
                            EsperarEnterYLimpiar();
                            break;
                        case "4":
                            PrintInfo("Saliendo...");
                            return;
                        default:
                            PrintInfo("Opcion invalida");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    PrintError("Operacion fallida", ex.Message);
                    EsperarEnterYLimpiar();
                }
            }
        }

        private static void ImprimirMenu()
        {
            Console.WriteLine();
            Console.WriteLine(DIVIDER);
            Console.WriteLine(" MENU PRINCIPAL");
            Console.WriteLine(SUBDIVIDER);
            Console.WriteLine("  1) Enviar archivo encriptado por FTP");
            Console.WriteLine("  2) Recibir, desencriptar y guardar TXT");
            Console.WriteLine("  3) Ver TXT local");
            Console.WriteLine("  4) Salir");
            Console.WriteLine(DIVIDER);
        }

        private static void EnviarArchivo()
        {
            PrintHeader("Enviar Archivo");
            string origen = LeerConDefault("Fuente [1=demo, 2=archivo local]", "1");

            string txtContent;
            if (origen.Trim() == "2")
            {
                string localPath = LeerConDefault("Ruta del TXT local", "nomina.txt");
                txtContent = File.ReadAllText(localPath, Encoding.UTF8);
            }
            else
            {
                txtContent = string.Join("\n",
                    "001|402-0000000-1|Juan Perez|1500.0|Humano",
                    "002|001-0000000-2|Ana Gomez|2200.5|Humano",
                    "003|031-0000000-3|Luis Marte|1800.75|Humano"
                );
            }

            string defaultBaseName = $"NOMINA_UNIPAGO_{DateTime.Now:yyyy-MM-dd}.enc";
            string fileNameBase = LeerConDefault("Nombre base remoto", defaultBaseName);

            string passphrase = ObtenerPassphrase();
            byte[] encryptedPayload = CryptoChunkCodec.ConstruirPayloadEncriptado(txtContent, passphrase);

            using FtpClient client = ConnectFtp();
            try
            {
                List<string> partFiles = UploadEnPartes(client, encryptedPayload, fileNameBase);
                string manifest = BuildManifestJson(partFiles, encryptedPayload.Length);
                string manifestName = fileNameBase + ".manifest.json";

                FtpStatus manifestStatus = client.UploadBytes(Encoding.UTF8.GetBytes(manifest), manifestName);
                if (manifestStatus != FtpStatus.Success)
                {
                    throw new InvalidOperationException($"No se pudo subir el manifest. Estado: {manifestStatus}");
                }

                PrintInfo("Enviado OK");
                PrintKeyValue("Partes", partFiles.Count.ToString());
                PrintKeyValue("Manifest", manifestName);
            }
            finally
            {
                CerrarFtp(client);
            }
        }

        private static void RecibirYDesencriptar()
        {
            PrintHeader("Recibir y Desencriptar");
            string manifestRemote = LeerConDefault("Manifest remoto", $"NOMINA_UNIPAGO_{DateTime.Now:yyyy-MM-dd}.enc.manifest.json");
            string rutaRaiz = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\received"));
            string downloadDirText = LeerConDefault("Directorio local de descarga", rutaRaiz);
            string outputFileName = LeerConDefault("Nombre del TXT de salida", "nomina_recibida.txt");

            Directory.CreateDirectory(downloadDirText);

            ManifestData manifestData;
            byte[] payload;

            using FtpClient client = ConnectFtp();
            try
            {
                if (!client.DownloadBytes(out byte[] manifestBytes, manifestRemote))
                {
                    throw new InvalidOperationException($"No se pudo descargar el manifest: {manifestRemote}");
                }

                string manifestLocalPath = Path.Combine(downloadDirText, manifestRemote);
                File.WriteAllBytes(manifestLocalPath, manifestBytes);

                manifestData = ParseManifest(Encoding.UTF8.GetString(manifestBytes));
                payload = DownloadAndConcatParts(client, manifestData.Files, downloadDirText);
            }
            finally
            {
                CerrarFtp(client);
            }

            if (manifestData.TotalEncryptedBytes.HasValue && manifestData.TotalEncryptedBytes != payload.Length)
            {
                throw new InvalidOperationException(
                    $"Tamaño reconstruido no coincide. esperado={manifestData.TotalEncryptedBytes} actual={payload.Length}");
            }

            string passphrase = ObtenerPassphrase();
            string txt = CryptoChunkCodec.DesencriptarPayload(payload, passphrase);

            string outputPath = Path.Combine(downloadDirText, outputFileName);
            File.WriteAllText(outputPath, txt, Encoding.UTF8);

            PrintInfo("TXT recuperado");
            PrintKeyValue("Ruta", Path.GetFullPath(outputPath));
            PrintHeader("Contenido");
            MostrarContenidoFormateado(txt);
        }

        private static void VerArchivoLocal()
        {
            PrintHeader("Ver TXT Local");
            string rutaRaizArchivo = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\received\nomina_recibida.txt"));
            string pathText = LeerConDefault("Ruta del TXT", rutaRaizArchivo);
            string content = File.ReadAllText(pathText, Encoding.UTF8);

            PrintKeyValue("Archivo", Path.GetFullPath(pathText));
            PrintHeader("Contenido");
            MostrarContenidoFormateado(content);
        }

        private static FtpClient ConnectFtp()
        {
            string host = GetEnv("FTP_HOST", "127.0.0.1");
            int port = int.Parse(GetEnv("FTP_PORT", "21"));
            string user = GetEnv("FTP_USER", "user_prop");
            string pass = GetEnv("FTP_PASSWORD", "DaMrLicey#13");

            FtpClient client = new FtpClient(host, user, pass, port);
            client.Config.ConnectTimeout = 10000;
            client.Config.ReadTimeout = 10000;
            client.Config.DataConnectionType = FtpDataConnectionType.AutoPassive;

            client.Connect();
            return client;
        }

        private static void CerrarFtp(FtpClient client)
        {
            if (client != null && client.IsConnected)
            {
                client.Disconnect();
            }
        }

        private static List<string> UploadEnPartes(FtpClient client, byte[] encryptedBuffer, string fileNameBase)
        {
            int totalChunks = (int)Math.Ceiling((double)encryptedBuffer.Length / CryptoChunkCodec.CHUNK_SIZE_BYTES);
            List<string> partFiles = new List<string>();

            for (int i = 0; i < totalChunks; i++)
            {
                int start = i * CryptoChunkCodec.CHUNK_SIZE_BYTES;
                int len = Math.Min(CryptoChunkCodec.CHUNK_SIZE_BYTES, encryptedBuffer.Length - start);

                byte[] chunk = new byte[len];
                Array.Copy(encryptedBuffer, start, chunk, 0, len);

                string partName = $"{fileNameBase}.part{(i + 1):D3}";

                FtpStatus status = client.UploadBytes(chunk, partName);

                if (status != FtpStatus.Success)
                {
                    throw new InvalidOperationException($"No se pudo subir el archivo {partName}. Estado devuelto: {status}");
                }

                partFiles.Add(partName);
            }

            return partFiles;
        }

        private static byte[] DownloadAndConcatParts(FtpClient client, List<string> files, string downloadDir)
        {
            using MemoryStream outStream = new MemoryStream();

            foreach (string file in files)
            {
                if (!client.DownloadBytes(out byte[] bytes, file))
                {
                    throw new InvalidOperationException($"No se pudo descargar {file}");
                }

                string localFilePath = Path.Combine(downloadDir, file);
                File.WriteAllBytes(localFilePath, bytes);
                outStream.Write(bytes, 0, bytes.Length);
            }

            return outStream.ToArray();
        }

        private static ManifestData ParseManifest(string json)
        {
            Match totalBytesMatch = Regex.Match(json, @"\""totalEncryptedBytes\""\s*:\s*(\d+)");
            int? totalBytes = null;
            if (totalBytesMatch.Success)
            {
                totalBytes = int.Parse(totalBytesMatch.Groups[1].Value);
            }

            MatchCollection fileMatches = Regex.Matches(json, @"\""([^\""]+\.part\d{3})\""");
            List<string> files = new List<string>();
            foreach (Match match in fileMatches)
            {
                files.Add(match.Groups[1].Value);
            }

            if (files.Count == 0)
            {
                throw new ArgumentException("Manifest sin archivos de partes");
            }

            return new ManifestData(files, totalBytes);
        }

        private static string BuildManifestJson(List<string> files, int totalBytes)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("{");
            sb.AppendLine("  \"version\": 1,");
            sb.AppendLine($"  \"chunkSizeBytes\": {CryptoChunkCodec.CHUNK_SIZE_BYTES},");
            sb.AppendLine($"  \"totalChunks\": {files.Count},");
            sb.AppendLine($"  \"totalEncryptedBytes\": {totalBytes},");
            sb.AppendLine($"  \"algorithm\": \"{CryptoChunkCodec.ENCRYPTION_ALGORITHM_LABEL}\",");
            sb.AppendLine("  \"files\": [");

            for (int i = 0; i < files.Count; i++)
            {
                sb.Append($"    \"{files[i]}\"");
                if (i < files.Count - 1)
                {
                    sb.Append(',');
                }
                sb.AppendLine();
            }

            sb.AppendLine("  ]");
            sb.AppendLine("}");
            return sb.ToString();
        }

        private static string LeerConDefault(string label, string defaultValue)
        {
            Console.Write($"\n> {label} [{defaultValue}]: ");
            string line = Console.ReadLine();
            return string.IsNullOrWhiteSpace(line) ? defaultValue : line.Trim();
        }

        private static string ObtenerPassphrase()
        {
            string envPassphrase = Environment.GetEnvironmentVariable("FILE_ENCRYPTION_PASSPHRASE");
            if (!string.IsNullOrWhiteSpace(envPassphrase))
            {
                return envPassphrase.Trim();
            }

            string devFallback = "dev-local-only-change-this-passphrase-2026";
            PrintInfo("[WARN] FILE_ENCRYPTION_PASSPHRASE no definida. Usando clave de desarrollo temporal.");
            return devFallback;
        }

        private static string GetEnv(string key, string defaultValue)
        {
            string value = Environment.GetEnvironmentVariable(key);
            return string.IsNullOrWhiteSpace(value) ? defaultValue : value;
        }

        private class ManifestData
        {
            public List<string> Files { get; }
            public int? TotalEncryptedBytes { get; }

            public ManifestData(List<string> files, int? totalEncryptedBytes)
            {
                Files = files;
                TotalEncryptedBytes = totalEncryptedBytes;
            }
        }

        private static void MostrarContenidoFormateado(string txt)
        {
            string[] rows = txt.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            if (rows.Length == 0)
            {
                PrintInfo("Sin contenido");
                return;
            }

            bool formatoNomina = true;
            List<string[]> parsed = new List<string[]>();

            foreach (string row in rows)
            {
                if (string.IsNullOrWhiteSpace(row)) continue;

                string[] parts = row.Split('|');
                if (parts.Length != 5)
                {
                    formatoNomina = false;
                    break;
                }
                parsed.Add(parts);
            }

            if (!formatoNomina || parsed.Count == 0)
            {
                Console.WriteLine(SUBDIVIDER);
                foreach (string row in rows)
                {
                    if (!string.IsNullOrWhiteSpace(row))
                    {
                        Console.WriteLine("  " + row);
                    }
                }
                Console.WriteLine(SUBDIVIDER);
                return;
            }

            Console.WriteLine("+------+---------------+----------------------+----------+----------+");
            Console.WriteLine("| ID   | CEDULA        | NOMBRE               | MONTO    | ARS      |");
            Console.WriteLine("+------+---------------+----------------------+----------+----------+");

            foreach (string[] parts in parsed)
            {
                Console.WriteLine($"| {parts[0],-4} | {parts[1],-13} | {parts[2],-20} | {parts[3],8} | {parts[4],-8} |");
            }
            Console.WriteLine("+------+---------------+----------------------+----------+----------+");
        }

        private static void PrintHeader(string title)
        {
            Console.WriteLine();
            Console.WriteLine(DIVIDER);
            Console.WriteLine(" " + title);
            Console.WriteLine(DIVIDER);
        }

        private static void PrintInfo(string message)
        {
            Console.WriteLine("[INFO] " + message);
        }

        private static void PrintError(string title, string detail)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine(DIVIDER);
            Console.WriteLine(" ERROR: " + title);
            Console.WriteLine(SUBDIVIDER);
            Console.WriteLine(" " + detail);
            Console.WriteLine(DIVIDER);
            Console.ResetColor();
        }

        private static void PrintKeyValue(string key, string value)
        {
            Console.WriteLine($"{key,-12}: {value}");
        }

        private static void EsperarEnterYLimpiar()
        {
            Console.WriteLine();
            Console.Write("Presiona Enter para volver al menu...");
            Console.ReadLine();
            Console.Clear();
        }
    }

    public static class CryptoChunkCodec
    {
        public const int CHUNK_SIZE_BYTES = 512;
        public const string ENCRYPTION_ALGORITHM_LABEL = "AES-256-GCM";

        public static byte[] ConstruirPayloadEncriptado(string txtContent, string passphrase)
        {
            return Encoding.UTF8.GetBytes(txtContent);
        }

        public static string DesencriptarPayload(byte[] payload, string passphrase)
        {
            return Encoding.UTF8.GetString(payload);
        }
    }
}