using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Curso.DataAccess.Models
{
    public partial class Personas
    {
        public int Id { get; set; }

        [Display(Name = "Nombre de la persona")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? Hermanos { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime FechaDeNacimiento { get; set; }
        public int IdTipoPersona { get; set; }

        public virtual PersonasTipo IdTipoPersonaNavigation { get; set; }
    }
}
