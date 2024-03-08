using System;
using System.Collections.Generic;

namespace PlatillosAPI_JosueVargasMatamoros.Models;

public partial class TblPlatilloIngrediente
{
    public int IdPlatilloIngrediente { get; set; }

    public int IdPlatillo { get; set; }

    public int IdIngrediente { get; set; }

    public virtual TblIngrediente IdIngredienteNavigation { get; set; } = null!;

    public virtual TblPlatillo IdPlatilloNavigation { get; set; } = null!;
}
