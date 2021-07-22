using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Curso.DataAccess.Models
{
    public partial class Logs
    {
        public int Id { get; set; }
        public bool IsError { get; set; }
        public string Description { get; set; }
        public string Message { get; set; }
    }
}
