using System;
using System.Collections.Generic;

namespace WSventa.Models;

public partial class Usuario
{
    public long Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Nombre { get; set; } = null!;
}
