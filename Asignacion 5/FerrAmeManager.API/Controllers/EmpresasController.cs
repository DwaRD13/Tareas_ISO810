using Microsoft.AspNetCore.Mvc;
using FerrAmeManager.API.Data;

namespace FerrAmeManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresasController : ControllerBase
    {
        private readonly AppDbContext _db;

        public EmpresasController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmpresas()
        {
            var empresas = await _db.GetEmpresasAsync();
            return Ok(empresas);
        }
    }
}
