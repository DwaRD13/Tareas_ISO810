using System;
using System.Collections.Generic;

namespace Cuentas_X_Cobrar_FarmaciaCarol.Data.Models;

public partial class CxC_Movimiento
{
    public long MovimientoId { get; set; }

    public long DocumentoId { get; set; }

    public string TipoMovimiento { get; set; } = null!;

    public decimal Monto { get; set; }

    public DateTime Fecha { get; set; }

    public string? ReferenciaExterna { get; set; }

    public string? Descripcion { get; set; }

    public virtual CxC_Documento Documento { get; set; } = null!;
}
