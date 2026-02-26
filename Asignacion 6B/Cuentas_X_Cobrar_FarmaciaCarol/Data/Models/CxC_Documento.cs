using System;
using System.Collections.Generic;

namespace Cuentas_X_Cobrar_FarmaciaCarol.Data.Models;

public partial class CxC_Documento
{
    public long DocumentoId { get; set; }

    public long ClienteId { get; set; }

    public string TipoDocumento { get; set; } = null!;

    public string ReferenciaExterna { get; set; } = null!;

    public DateOnly FechaEmision { get; set; }

    public DateOnly? FechaVencimiento { get; set; }

    public decimal MontoOriginal { get; set; }

    public decimal SaldoActual { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public virtual ICollection<CxC_Movimiento> CxC_Movimientos { get; set; } = new List<CxC_Movimiento>();
}
