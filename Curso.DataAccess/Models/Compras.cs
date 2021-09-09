using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Curso.DataAccess.Models
{
    public partial class Compras
    {
        public int IdCompras { get; set; }
        public int? NroCompra { get; set; }
        public byte[] FechaCompra { get; set; }
        public string PuntoDeVenta { get; set; }
        public int? IdCompraDetalle { get; set; }
        public int? Idformapago { get; set; }
        public bool? Borrado { get; set; }

        public virtual ComprasDetalle IdCompraDetalleNavigation { get; set; }
        public virtual FormaDePago IdformapagoNavigation { get; set; }
    }
}
