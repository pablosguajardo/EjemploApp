using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Curso.DataAccess.Models
{
    public partial class PersonasSubTipo
    {
        public PersonasSubTipo()
        {
            Personas = new HashSet<Personas>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdPersonasTipo { get; set; }

        public virtual PersonasTipo IdPersonasTipoNavigation { get; set; }
        public virtual ICollection<Personas> Personas { get; set; }
    }
}
