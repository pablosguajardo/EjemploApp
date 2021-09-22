using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Curso.DataAccess.Models
{
    public partial class ProductoTipo
    {
        public ProductoTipo()
        {
            ProductoSubTipo = new HashSet<ProductoSubTipo>();
            Productos = new HashSet<Productos>();
        }

        public int IdProductoTipo { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public bool Borrado { get; set; }
        public string CampoNuevo { get; set; }

        public virtual ICollection<ProductoSubTipo> ProductoSubTipo { get; set; }
        public virtual ICollection<Productos> Productos { get; set; }
    }
}
