using System;
using System.Collections.Generic;

namespace PlatillosAPI_JosueVargasMatamoros.Models;

public partial class TblCliente
{
    public int IdCliente { get; set; }

    public string PrimerApellido { get; set; } = null!;

    public string SegundoApellido { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Telefono1 { get; set; } = null!;

    public string? Telefono2 { get; set; }

    public virtual ICollection<TblFactura> TblFacturas { get; set; } = new List<TblFactura>();
}
