using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Curso.DataAccess.Models
{
    public partial class Ventas
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public int IdVentasDetalle { get; set; }
        public bool? Borrado { get; set; }
        public string ClientName { get; set; }

        public virtual VentasDetalle IdVentasDetalleNavigation { get; set; }
    }
}
