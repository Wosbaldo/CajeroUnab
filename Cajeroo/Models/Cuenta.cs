using System;
using System.Collections.Generic;

namespace Cajeroo.Models;

public partial class Cuenta
{
    public int IdPassword { get; set; }

    public int? NumCuenta { get; set; }

    public decimal? Saldo { get; set; }
}
