using Microsoft.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace FerrAmeManager
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            CrearBaseDeDatosSiNoExiste();
            Application.Run(new Form1());
        }

        private static void CrearBaseDeDatosSiNoExiste()
        {
            string connectionStringMaster = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True";

            string script = File.ReadAllText("DB/ScriptDB.sql");

            using (SqlConnection con = new SqlConnection(connectionStringMaster))
            {
                con.Open();

                string[] commands = script.Split(new[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var command in commands)
                {
                    // Limpiamos espacios vacíos y saltos de línea extra
                    string cleanCommand = command.Trim();

                    // Solo ejecutamos si hay texto real (evita errores por líneas vacías)
                    if (!string.IsNullOrEmpty(cleanCommand))
                    {
                        using (SqlCommand cmd = new SqlCommand(cleanCommand, con))
                        {
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                // Esto te ayudará a saber exactamente qué parte del script falló si vuelve a pasar
                                MessageBox.Show($"Error ejecutando el comando:\n{cleanCommand}\n\nDetalle: {ex.Message}");
                            }
                        }
                    }
                }
            }
        }
    }
}