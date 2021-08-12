using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Curso.DataAccess.Models
{
    public partial class PersonaLog
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? Hermanos { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public int IdPersona { get; set; }

        public virtual Personas IdPersonaNavigation { get; set; }
    }
}
