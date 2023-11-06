using System;
using System.Collections.Generic;

namespace FacturaCRUD.Models;

public partial class Factura
{
    public int Id { get; set; }

    public string? Nit { get; set; }

    public string? Nombre { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Correlativo { get; set; }

    public decimal? MontoTotal { get; set; }

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();
}
