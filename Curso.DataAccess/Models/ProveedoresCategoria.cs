using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Curso.DataAccess.Models
{
    public partial class ProveedoresCategoria
    {
        public ProveedoresCategoria()
        {
            Proveedores = new HashSet<Proveedores>();
        }

        public int IdCategoriaProveedores { get; set; }
        public string NombreCategoria { get; set; }
        public string DescripcionCategoria { get; set; }
        public bool? Borrado { get; set; }

        public virtual ICollection<Proveedores> Proveedores { get; set; }
    }
}
