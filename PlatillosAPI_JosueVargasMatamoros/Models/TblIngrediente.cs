using System;
using System.Collections.Generic;

namespace PlatillosAPI_JosueVargasMatamoros.Models;

public partial class TblIngrediente
{
    public int IdIngrediente { get; set; }

    public string CodigoIngrediente { get; set; } = null!;

    public string NombreIngrediente { get; set; } = null!;

    public decimal PrecioIngrediente { get; set; }

    public virtual ICollection<TblPlatilloIngrediente> TblPlatilloIngredientes { get; set; } = new List<TblPlatilloIngrediente>();
}
