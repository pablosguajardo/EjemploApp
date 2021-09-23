using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Curso.DataAccess.Models
{
    public partial class Productos
    {
        public int ProductId { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public int Precio { get; set; }
        public int IdProductoTipo { get; set; }
        public int IdProductoCategoria { get; set; }
        public int? IdProductoSubTipo { get; set; }
        public bool? Borrado { get; set; }
        public string Descripcion { get; set; }

        public virtual CategoriaProducto IdProductoCategoriaNavigation { get; set; }
        public virtual ProductoSubTipo IdProductoSubTipoNavigation { get; set; }
        public virtual ProductoTipo IdProductoTipoNavigation { get; set; }
    }
}
