﻿using System;
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
        public int? IdProductoCategoriaNavigationIdCategoriaProducto { get; set; }
        public int? IdProductoTipoNavigationIdProductoTipo { get; set; }

        public virtual CategoriaProducto IdProductoCategoriaNavigationIdCategoriaProductoNavigation { get; set; }
        public virtual ProductoTipo IdProductoTipoNavigationIdProductoTipoNavigation { get; set; }
    }
}
