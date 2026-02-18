using Microsoft.Data.SqlClient;
using FerrAmeManager.API.Models;

namespace FerrAmeManager.API.Data
{
    public class AppDbContext
    {
        private readonly string _connectionString;

        public AppDbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public SqlConnection GetConnection() => new SqlConnection(_connectionString);

        // --- EMPRESAS ---

        public async Task<List<Empresa>> GetEmpresasAsync()
        {
            var empresas = new List<Empresa>();

            using var con = GetConnection();
            await con.OpenAsync();

            using var cmd = new SqlCommand("SELECT Id, Nombre, RNC FROM Empresas", con);
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                empresas.Add(new Empresa
                {
                    Id     = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    RNC    = reader.GetString(2)
                });
            }

            return empresas;
        }

        // --- EMPLEADOS ---

        public async Task<List<Empleado>> GetEmpleadosAsync(int? empresaId = null)
        {
            var empleados = new List<Empleado>();

            using var con = GetConnection();
            await con.OpenAsync();

            var sql = @"SELECT Id, Cedula, Salario, FechaIngreso, TipoEmpleado, Cargo, EmpresaId
                        FROM Empleados";

            if (empresaId.HasValue)
                sql += " WHERE EmpresaId = @EmpresaId";

            sql += " ORDER BY Id DESC";

            using var cmd = new SqlCommand(sql, con);

            if (empresaId.HasValue)
                cmd.Parameters.AddWithValue("@EmpresaId", empresaId.Value);

            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                empleados.Add(new Empleado
                {
                    Id           = reader.GetInt32(0),
                    Cedula       = reader.GetString(1),
                    Salario      = reader.GetDecimal(2),
                    FechaIngreso = reader.GetDateTime(3),
                    TipoEmpleado = reader.GetString(4),
                    Cargo        = reader.GetString(5),
                    EmpresaId    = reader.GetInt32(6)
                });
            }

            return empleados;
        }

        public async Task<Empleado?> GetEmpleadoByIdAsync(int id)
        {
            using var con = GetConnection();
            await con.OpenAsync();

            using var cmd = new SqlCommand(
                "SELECT Id, Cedula, Salario, FechaIngreso, TipoEmpleado, Cargo, EmpresaId FROM Empleados WHERE Id = @Id",
                con);
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new Empleado
                {
                    Id           = reader.GetInt32(0),
                    Cedula       = reader.GetString(1),
                    Salario      = reader.GetDecimal(2),
                    FechaIngreso = reader.GetDateTime(3),
                    TipoEmpleado = reader.GetString(4),
                    Cargo        = reader.GetString(5),
                    EmpresaId    = reader.GetInt32(6)
                };
            }

            return null;
        }

        public async Task<Empleado> CrearEmpleadoAsync(CrearEmpleadoDto dto)
        {
            // Convertir "ddMMyyyy" → DateTime antes de tocar la DB
            if (!DateTime.TryParseExact(dto.FechaIngreso, "ddMMyyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out DateTime fechaIngreso))
            {
                throw new ArgumentException(
                    $"El formato de FechaIngreso es inválido: '{dto.FechaIngreso}'. Se esperaba ddMMyyyy (ej: 15012024).");
            }

            using var con = GetConnection();
            await con.OpenAsync();

            // Verificamos que la empresa exista
            using var cmdCheck = new SqlCommand("SELECT COUNT(1) FROM Empresas WHERE Id = @Id", con);
            cmdCheck.Parameters.AddWithValue("@Id", dto.EmpresaId);
            var existe = (int)await cmdCheck.ExecuteScalarAsync()!;

            if (existe == 0)
                throw new ArgumentException($"No existe una empresa con Id = {dto.EmpresaId}");

            using var cmd = new SqlCommand(@"
                INSERT INTO Empleados (EmpresaId, Cedula, Salario, FechaIngreso, TipoEmpleado, Cargo)
                OUTPUT INSERTED.Id
                VALUES (@EmpresaId, @Cedula, @Salario, @FechaIngreso, @TipoEmpleado, @Cargo)",
                con);

            cmd.Parameters.AddWithValue("@EmpresaId",    dto.EmpresaId);
            cmd.Parameters.AddWithValue("@Cedula",       dto.Cedula);
            cmd.Parameters.AddWithValue("@Salario",      dto.Salario);
            cmd.Parameters.AddWithValue("@FechaIngreso", fechaIngreso); // DateTime limpio
            cmd.Parameters.AddWithValue("@TipoEmpleado", dto.TipoEmpleado);
            cmd.Parameters.AddWithValue("@Cargo",        dto.Cargo);

            var newId = (int)await cmd.ExecuteScalarAsync()!;

            return new Empleado
            {
                Id           = newId,
                Cedula       = dto.Cedula,
                Salario      = dto.Salario,
                FechaIngreso = fechaIngreso,
                TipoEmpleado = dto.TipoEmpleado,
                Cargo        = dto.Cargo,
                EmpresaId    = dto.EmpresaId
            };
        }
    }
}
