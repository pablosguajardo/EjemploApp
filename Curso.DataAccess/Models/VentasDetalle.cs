using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Curso.DataAccess.Models
{
    public partial class VentasDetalle
    {
        public VentasDetalle()
        {
            Ventas = new HashSet<Ventas>();
        }

        public int IdDetalleVenta { get; set; }
        public decimal Subtotal { get; set; }
        public int Cantidad { get; set; }
        public int IdCompra { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public int? IdProducto { get; set; }

        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
