using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Curso.DataAccess.Models
{
    public partial class ComprasDetalle
    {
        public ComprasDetalle()
        {
            Compras = new HashSet<Compras>();
        }

        public int IdComprasDetalle { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Compras> Compras { get; set; }
    }
}
