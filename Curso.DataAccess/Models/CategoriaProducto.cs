using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Curso.DataAccess.Models
{
    public partial class CategoriaProducto
    {
        public CategoriaProducto()
        {
            Productos = new HashSet<Productos>();
        }

        public int IdCategoriaProducto { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public bool? Borrado { get; set; }


        public virtual ICollection<Productos> Productos { get; set; }
    }
}
