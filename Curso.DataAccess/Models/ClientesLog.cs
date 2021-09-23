using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Curso.DataAccess.Models
{
    public partial class ClientesLog
    {
        public int Id { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public int ClienteTipoId { get; set; }
        public int ClienteCategoriaId { get; set; }
        public int IdCliente { get; set; }
        public string IdUsuario { get; set; }
        public bool? Borrado { get; set; }
        public string Localidad { get; set; }

        public virtual Clientes IdClienteNavigation { get; set; }
        public virtual AspNetUsers IdUsuarioNavigation { get; set; }
    }
}
