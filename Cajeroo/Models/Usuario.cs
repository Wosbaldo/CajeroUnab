using System;
using System.Collections.Generic;

namespace Cajeroo.Models;

public partial class Usuario
{
    public int IdPassword { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }
}
