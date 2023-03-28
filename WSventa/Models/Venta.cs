using System;
using System.Collections.Generic;

namespace WSventa.Models;

public partial class Venta
{
    public long Id { get; set; }

    public long? IdCliente { get; set; }

    public DateTime Fecha { get; set; }

    public decimal? Total { get; set; }

    public virtual ICollection<Concepto> Conceptos { get; } = new List<Concepto>();

    public virtual Cliente? IdClienteNavigation { get; set; }
}
