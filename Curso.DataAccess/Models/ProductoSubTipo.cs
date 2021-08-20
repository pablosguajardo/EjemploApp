using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Curso.DataAccess.Models
{
    public partial class ProductoSubTipo
    {
        public ProductoSubTipo()
        {
            Productos = new HashSet<Productos>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public int IdProductoTipo { get; set; }

        public virtual ProductoTipo IdProductoTipoNavigation { get; set; }
        public virtual ICollection<Productos> Productos { get; set; }
    }
}
