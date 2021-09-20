using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Curso.DataAccess.Models
{
    public partial class FormaDePago
    {
        public FormaDePago()
        {
            Compras = new HashSet<Compras>();
        }

        public int Id { get; set; }
        public string Descripción { get; set; }
        public bool? Borrado { get; set; }

        public virtual ICollection<Compras> Compras { get; set; }
    }
}
