using System;
using System.Collections.Generic;

namespace FacturaCRUD.Models;

public partial class DetalleFactura
{
    public int Id { get; set; }

    public string? Producto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? MontoTotalLinea { get; set; }

    public int? FacturaId { get; set; }

    public virtual Factura? Factura { get; set; }
}
