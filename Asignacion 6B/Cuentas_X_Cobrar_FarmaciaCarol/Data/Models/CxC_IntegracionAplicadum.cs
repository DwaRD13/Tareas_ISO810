using System;
using System.Collections.Generic;

namespace Cuentas_X_Cobrar_FarmaciaCarol.Data.Models;

public partial class CxC_IntegracionAplicadum
{
    public string TipoEvento { get; set; } = null!;

    public long EntidadId { get; set; }

    public DateTime FechaAplicado { get; set; }
}
