using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cuentas_X_Cobrar_FarmaciaCarol.Data;

namespace Cuentas_X_Cobrar_FarmaciaCarol.Controllers;

[ApiController]
[Route("api/cxc/documentos")]
public class DocumentosController : ControllerBase
{
    private readonly CxCDbContext _db;

    public DocumentosController(CxCDbContext db) => _db = db;

    // GET /api/cxc/documentos?clienteId=1&estado=ABIERTO&ref=FAC-123
    [HttpGet]
    public async Task<IActionResult> Listar([FromQuery] long? clienteId, [FromQuery] string? estado, [FromQuery] string? refExterna)
    {
        var q = _db.CxC_Documentos.AsNoTracking().AsQueryable();

        if (clienteId is not null) q = q.Where(d => d.ClienteId == clienteId);
        if (!string.IsNullOrWhiteSpace(estado)) q = q.Where(d => d.Estado == estado);
        if (!string.IsNullOrWhiteSpace(refExterna)) q = q.Where(d => d.ReferenciaExterna == refExterna);

        var data = await q
            .OrderByDescending(d => d.FechaCreacion)
            .Select(d => new
            {
                d.DocumentoId,
                d.ClienteId,
                d.TipoDocumento,
                d.ReferenciaExterna,
                d.FechaEmision,
                d.FechaVencimiento,
                d.MontoOriginal,
                d.SaldoActual,
                d.Estado,
                d.FechaCreacion
            })
            .ToListAsync();

        return Ok(data);
    }

    // GET /api/cxc/documentos/10
    [HttpGet("{id:long}")]
    public async Task<IActionResult> Get(long id)
    {
        var doc = await _db.CxC_Documentos.AsNoTracking()
            .Where(d => d.DocumentoId == id)
            .Select(d => new
            {
                d.DocumentoId,
                d.ClienteId,
                d.TipoDocumento,
                d.ReferenciaExterna,
                d.FechaEmision,
                d.FechaVencimiento,
                d.MontoOriginal,
                d.SaldoActual,
                d.Estado,
                d.FechaCreacion
            })
            .FirstOrDefaultAsync();

        return doc is null ? NotFound() : Ok(doc);
    }

    // GET /api/cxc/documentos/10/movimientos
    [HttpGet("{id:long}/movimientos")]
    public async Task<IActionResult> Movimientos(long id)
    {
        var movs = await _db.CxC_Movimientos.AsNoTracking()
            .Where(m => m.DocumentoId == id)
            .OrderBy(m => m.Fecha)
            .Select(m => new
            {
                m.MovimientoId,
                m.DocumentoId,
                m.TipoMovimiento,
                m.Monto,
                m.Fecha,
                m.ReferenciaExterna,
                m.Descripcion
            })
            .ToListAsync();

        return Ok(movs);
    }
}