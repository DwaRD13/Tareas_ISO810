using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cuentas_X_Cobrar_FarmaciaCarol.Data;

namespace Cuentas_X_Cobrar_FarmaciaCarol.Controllers;

[ApiController]
[Route("api/cxc/integracion")]
public class IntegracionController : ControllerBase
{
    private readonly CxCDbContext _db;

    public IntegracionController(CxCDbContext db) => _db = db;

    [HttpPost("facturas/{facturaId:long}/aplicar")]
    public async Task<IActionResult> AplicarFactura(long facturaId)
    {
        await _db.Database.ExecuteSqlInterpolatedAsync(
            $"EXEC dbo.sp_CxC_AplicarFactura @FacturaId={facturaId}");
        return Ok(new { ok = true, facturaId });
    }

    [HttpPost("pagos/{pagoId:long}/aplicar")]
    public async Task<IActionResult> AplicarPago(long pagoId)
    {
        await _db.Database.ExecuteSqlInterpolatedAsync(
            $"EXEC dbo.sp_CxC_AplicarPago @PagoId={pagoId}");
        return Ok(new { ok = true, pagoId });
    }

    [HttpPost("notas-credito/{notaCreditoId:long}/aplicar")]
    public async Task<IActionResult> AplicarNotaCredito(long notaCreditoId)
    {
        await _db.Database.ExecuteSqlInterpolatedAsync(
            $"EXEC dbo.sp_CxC_AplicarNotaCredito @NotaCreditoId={notaCreditoId}");
        return Ok(new { ok = true, notaCreditoId });
    }

    [HttpPost("facturas/{facturaId:long}/anular")]
    public async Task<IActionResult> AnularFactura(long facturaId)
    {
        await _db.Database.ExecuteSqlInterpolatedAsync(
            $"EXEC dbo.sp_CxC_AnularFactura @FacturaId={facturaId}");
        return Ok(new { ok = true, facturaId });
    }
}