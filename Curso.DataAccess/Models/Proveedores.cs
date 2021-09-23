using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Curso.DataAccess.Models
{
    public partial class Proveedores
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public int IdTipoProveedores { get; set; }
        public int IdCategoriaProveedores { get; set; }
        public bool? Borrado { get; set; }
        public string Domicilio { get; set; }

        public virtual ProveedoresCategoria IdCategoriaProveedoresNavigation { get; set; }
    }
}
