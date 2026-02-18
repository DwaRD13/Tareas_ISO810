using Microsoft.AspNetCore.Mvc;
using FerrAmeManager.API.Data;
using FerrAmeManager.API.Models;

namespace FerrAmeManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly AppDbContext _db;

        public EmpleadosController(AppDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Ejemplo: GET /api/empleados
        ///          GET /api/empleados?empresaId=1
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetEmpleados([FromQuery] int? empresaId)
        {
            var empleados = await _db.GetEmpleadosAsync(empresaId);
            return Ok(empleados);
        }

        /// <summary>
        /// Ejemplo: GET /api/empleados/5
        /// </summary>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmpleado(int id)
        {
            var empleado = await _db.GetEmpleadoByIdAsync(id);

            if (empleado is null)
                return NotFound(new { message = $"Empleado con Id {id} no encontrado." });

            return Ok(empleado);
        }

        /// <summary>
        /// Body ejemplo:
        /// {
        ///   "cedula": "00112345678",
        ///   "salario": 35000.00,
        ///   "fechaIngreso": "2024-01-15T00:00:00",
        ///   "tipoEmpleado": "F",
        ///   "cargo": "Vendedor",
        ///   "empresaId": 1
        /// }
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CrearEmpleado([FromBody] CrearEmpleadoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var empleado = await _db.CrearEmpleadoAsync(dto);

                return CreatedAtAction(nameof(GetEmpleado), new { id = empleado.Id }, empleado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error interno: " + ex.Message });
            }
        }
    }
}
