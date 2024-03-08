using System;
using System.Collections.Generic;

namespace PlatillosAPI_JosueVargasMatamoros.Models;

public partial class TblPlatillo
{
    public int IdPlatillo { get; set; }

    public string CodigoPlatillo { get; set; } = null!;

    public string NombrePlatillo { get; set; } = null!;

    public decimal? Precio { get; set; }

    public virtual ICollection<TblFactura> TblFacturas { get; set; } = new List<TblFactura>();

    public virtual ICollection<TblPlatilloIngrediente> TblPlatilloIngredientes { get; set; } = new List<TblPlatilloIngrediente>();
}
