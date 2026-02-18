namespace FerrAmeManager.API.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Cedula { get; set; } = string.Empty;
        public decimal Salario { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string TipoEmpleado { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public int EmpresaId { get; set; }
    }

    public class CrearEmpleadoDto
    {
        public string Cedula { get; set; } = string.Empty;
        public decimal Salario { get; set; }

        /// <summary>
        /// Fecha en formato ddMMyyyy — ejemplo: "01011990"
        /// </summary>
        public string FechaIngreso { get; set; } = string.Empty;

        public string TipoEmpleado { get; set; } = string.Empty;
        public string Cargo { get; set; } = string.Empty;
        public int EmpresaId { get; set; }
    }
}
