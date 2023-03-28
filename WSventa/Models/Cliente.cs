using System;
using System.Collections.Generic;

namespace WSventa.Models;

public partial class Cliente
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Venta> Venta { get; } = new List<Venta>();
}
