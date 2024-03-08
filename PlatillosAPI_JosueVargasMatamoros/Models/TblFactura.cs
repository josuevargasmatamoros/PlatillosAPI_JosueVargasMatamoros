using System;
using System.Collections.Generic;

namespace PlatillosAPI_JosueVargasMatamoros.Models;

public partial class TblFactura
{
    public int IdFactura { get; set; }

    public int IdCliente { get; set; }

    public int IdPlatillo { get; set; }

    public int IdBebida { get; set; }

    public decimal? TotalPlatillo { get; set; }

    public int CantidaMililitrosBebida { get; set; }

    public decimal TotalBebida { get; set; }

    public decimal MontoAntesImpuestos { get; set; }

    public decimal MontoIva { get; set; }

    public decimal MontoTotal { get; set; }

    public virtual TblBebidum IdBebidaNavigation { get; set; } = null!;

    public virtual TblCliente IdClienteNavigation { get; set; } = null!;

    public virtual TblPlatillo IdPlatilloNavigation { get; set; } = null!;
}
