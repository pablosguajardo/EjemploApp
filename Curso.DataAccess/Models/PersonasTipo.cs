﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Curso.DataAccess.Models
{
    public partial class PersonasTipo
    {
        public PersonasTipo()
        {
            Personas = new HashSet<Personas>();
            PersonasSubTipo = new HashSet<PersonasSubTipo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Personas> Personas { get; set; }
        public virtual ICollection<PersonasSubTipo> PersonasSubTipo { get; set; }
    }
}
