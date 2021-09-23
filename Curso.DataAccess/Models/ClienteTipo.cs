using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Curso.DataAccess.Models
{
    public partial class ClienteTipo
    {
        public ClienteTipo()
        {
            Clientes = new HashSet<Clientes>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int CategoriaId { get; set; }
        public string Detalles { get; set; }
        public bool? Borrado { get; set; }

        public virtual ICollection<Clientes> Clientes { get; set; }
    }
}
