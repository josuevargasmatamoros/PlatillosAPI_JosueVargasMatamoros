using System;
using System.Collections.Generic;

namespace PlatillosAPI_JosueVargasMatamoros.Models;

public partial class TblBebidum
{
    public int IdBebida { get; set; }

    public string CodigoBebida { get; set; } = null!;

    public string NombreBebida { get; set; } = null!;

    public decimal PrecioBebidaMililitros { get; set; }

    public virtual ICollection<TblFactura> TblFacturas { get; set; } = new List<TblFactura>();
}
