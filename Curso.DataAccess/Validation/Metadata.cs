using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Curso.DataAccess.Validations
{
    public class Metadata
    {

        public  class PersonasMetadata
        {
            public int Id { get; set; }

            [Display(Name = "Nombre")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(100, ErrorMessage = "Máximo {1} caracteres")]
            public string Nombre { get; set; }


            [Display(Name = "Apellido")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(100, ErrorMessage = "Máximo {1} caracteres")]
            public string Apellido { get; set; }

            [Display(Name = "cantidad de hermanos")]
            public int? Hermanos { get; set; }

            [Display(Name = "Fecha de nacimiento")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [DataType(DataType.Date)]
            public DateTime FechaDeNacimiento { get; set; }

            [Display(Name = "Tipo")]
            public int IdTipoPersonaNavigation { get; set; }


        }

        public partial class ProductosMetadata
        {
            public int ProductId { get; set; }

            [Display(Name = "Nombre")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(50, ErrorMessage = "Máximo {1} caracteres")]
            public string Nombre { get; set; }

            [Display(Name = "Marca")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(50, ErrorMessage = "Máximo {1} caracteres")]
            public string Marca { get; set; }

            [Display(Name = "Precio")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            public int Precio { get; set; }

            [Display(Name = "Tipo")]
            public int IdProductoTipoNavigation { get; set; }

            [Display(Name = "Categoria")]
            public int IdProductoCategoriaNavigation { get; set; }
        }

        public partial class ProductoTipoMetadata
        {
            public int ProductId { get; set; }

            [Display(Name = "Descripcion")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(50, ErrorMessage = "Máximo {1} caracteres")]
            public string Descripcion { get; set; }

        }



        public class EjemploMetadata
        {
            [Display(Name = "Fecha alta cliente")]
            //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            [DataType(DataType.Date)]
            public DateTime FechaAlta { get; set; }



            public int Id { get; set; }

            [Display(Name = "Nombre")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            public string Nombre { get; set; }

            
        }
      

        public class AspNetUsersMetadata
        {
            public string Id { get; set; }

            [Display(Name = "Usuario")]
            public string UserName { get; set; }
            public string NormalizedUserName { get; set; }

            [Display(Name = "Email")]
            public string Email { get; set; }
          
            public string NormalizedEmail { get; set; }

            [Display(Name = "Email confirmado")]
            public bool EmailConfirmed { get; set; }
            public string PasswordHash { get; set; }
            public string SecurityStamp { get; set; }
            public string ConcurrencyStamp { get; set; }

            [Display(Name = "Número telefónico")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Número telefónico confirmado")]
            public bool PhoneNumberConfirmed { get; set; }
            public bool TwoFactorEnabled { get; set; }
            public DateTimeOffset? LockoutEnd { get; set; }
            public bool LockoutEnabled { get; set; }
            public int AccessFailedCount { get; set; }
        }
    }
}
