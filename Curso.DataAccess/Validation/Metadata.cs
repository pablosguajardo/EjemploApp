using Curso.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Curso.DataAccess.Validations
{
    public class Metadata
    {

        public class PersonasMetadata
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

            [Display(Name = "Dirección")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(50, ErrorMessage = "Máximo {1} caracteres")]
            public string Direccion { get; set; }

        }
        public partial class CategoriaProductosMetadata
        {
            public int IdCategoriaProductos { get; set; }

            [Display(Name = "Nombre")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(50, ErrorMessage = "Máximo {1} caracteres")]
            public string Nombre { get; set; }

            [Display(Name = "Categoria")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(50, ErrorMessage = "Máximo {1} caracteres")]
            public string Categoria { get; set; }
        }

        public partial class ClientesMetaData
        {
            [Display(Name = "Apellido")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(100, ErrorMessage = "Máximo {1} caracteres")]
            public string Apellido { get; set; }

            [Display(Name = "Nombre")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(100, ErrorMessage = "Máximo {1} caracteres")]
            public string Nombre { get; set; }

            [Display(Name = "Dirección")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(100, ErrorMessage = "Máximo {1} caracteres")]
            public string Direccion { get; set; }

            [EmailAddress]
            [Display(Name = "Email")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(30, ErrorMessage = "Máximo {1} caracteres")]
            public string Email { get; set; }

            [Display(Name = "Tipo de Cliente")]
            public int ClienteTipoId { get; set; }

            [Display(Name = "Categoria de Cliente")]
            public int ClienteCategoriaId { get; set; }
        }
        public partial class ClientesLogMetadata
        {

            [Display(Name = "Apellido del cliente")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(20, ErrorMessage = "Máximo {1} caracteres")]
            public string Apellido { get; set; }

            [Display(Name = "Nombre del cliente")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(20, ErrorMessage = "Máximo {1} caracteres")]
            public string Nombre { get; set; }

            [Display(Name = "Direccion")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(200, ErrorMessage = "Máximo {1} caracteres")]
            public string Direccion { get; set; }

            [EmailAddress]
            [Display(Name = "Email")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(30, ErrorMessage = "Máximo {1} caracteres")]
            public string Email { get; set; }

            [Display(Name = "Tipo de Cliente")]
            public int ClienteTipoId { get; set; }

            [Display(Name = "Categoria del Cliente")]
            public int ClienteCategoriaId { get; set; }

            [Display(Name = "Cliente Nro")]
            public int IdCliente { get; set; }

            [Display(Name = "Usuario")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(450, ErrorMessage = "Máximo {1} caracteres")]
            public string IdUsuario { get; set; }

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

            [Display(Name = "Descripción")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(50, ErrorMessage = "Máximo {1} caracteres")]
            public string Descripcion { get; set; }
        }

        public partial class ProductoTipoMetadata
        {
            public int ProductId { get; set; }
            
            [Display(Name = "Nombre")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(50, ErrorMessage = "Máximo {1} caracteres")]
            public string Nombre { get; set; }

            [Display(Name = "Descripcion")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(50, ErrorMessage = "Máximo {1} caracteres")]
            public string Descripcion { get; set; }

            [Display(Name = "Campo Nuevo")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(50, ErrorMessage = "Máximo {1} caracteres")]
            public string CampoNuevo { get; set; }

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

        public partial class ProveedoresMetadata
        {
            [Display(Name = "Nombre")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(50, ErrorMessage = "Máximo {1} caracteres")]
            public string Nombre { get; set; }
            [Display(Name = "Fecha de inscripcion")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [DataType(DataType.Date)]
            public DateTime FechaInscripcion { get; set; }
            [Display(Name = "Tipo")]
            public int IdTipoProveedores { get; set; }
            [Display(Name = "Categoria")]
            public int IdCategoriaProveedores { get; set; }
            [Display(Name = "Domicilio")]
            [DataType(DataType.Text)]
            [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
            public string Domicilio { get; set; }
            public bool Borrado { get; set; }

        }

        public partial class ProveedoresCategoriaMetadata
        {
            [Display(Name = "Nombre de la categoria")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(50, ErrorMessage = "Máximo {1} caracteres")]
            public string NombreCategoria { get; set; }
            [Display(Name = "Descripcion de la categoria")]
            [StringLength(100, ErrorMessage = "Máximo {1} caracteres")]
            public string DescripcionCategoria { get; set; }

        }

        public class VentasMetadata
        {
            [Display(Name = "ClientId")]
            [Required(ErrorMessage = "El campo ClientId es obligatorio.")]
            public int ClientId { get; set; }

            [Display(Name = "Total")]
            [Required(ErrorMessage = "El campo Total es obligatorio.")]
            public decimal Total { get; set; }

            [Display(Name = "Fecha")]
            [DataType(DataType.Date)]
            [Required(ErrorMessage = "El campo Fecha es obligatorio.")]
            public DateTime Fecha { get; set; }

            [Display(Name = "Descripcion")]
            [DataType(DataType.Text)]
            [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
            public string Descripcion { get; set; }

            [Display(Name = "IdVentasDetalle")]
            [Required(ErrorMessage = "El campo IdVentasDetalle es obligatorio.")]
            public int IdVentasDetalle { get; set; }

        }

        public partial class VentasDetalleMetadata
        {

            public int IdDetalleVenta { get; set; }
            [Display(Name = "Subtotal")]
            [Required(ErrorMessage = "Este campo es obligatorio.")]
            public double Subtotal { get; set; }

            [Display(Name = "Cantidad")]
            [Required(ErrorMessage = "Este campo es obligatorio.")]
            [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
            public int Cantidad { get; set; }

            [Display(Name = "ID de compra")]
            public int IdCompra { get; set; }

            [Display(Name = "Precio unitario")]
            [Required(ErrorMessage = "Este campo es obligatorio.")]
            [Range(0, 9999999999999999.99)]
            public double? PrecioUnitario { get; set; }

            [Display(Name = "ID Producto")]
            [Required(ErrorMessage = "Este campo es obligatorio.")]
            public int? IdProducto { get; set; }

            [Required(ErrorMessage = "Este campo es obligatorio.")]
            public string Descripcion { get; set; }

            public bool Borrado { get; set; }
            public virtual ICollection<Ventas> Ventas { get; set; }
        }

        public partial class ClienteTipoMetadata

        {
            [Display(Name = "Descripcion")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(50, ErrorMessage = "Máximo {1} caracteres")]
            public string Descripcion { get; set; }

            [Display(Name = "Categoria_ID")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            public int? CategoriaId { get; set; }

            [Display(Name = "Detalles")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(50, ErrorMessage = "Máximo {1} caracteres")]
            public string Detalles { get; set; }

        }

        public partial class ComprasMetadata
        {
            [Display(Name = "Numero de Compra")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [Range(0, 9999999)]
            public int? NroCompra { get; set; }

            [Display(Name = "Punto de Venta")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [DataType(DataType.Text)]
            [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
            public string PuntoDeVenta { get; set; }

            [Display(Name = "Fecha")]
            [DataType(DataType.Date)]
            [Required(ErrorMessage = "El campo Fecha de Compra es obligatorio.")]
            public DateTime FechaCompra { get; set; }

            [Display(Name = "Comentarios")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [DataType(DataType.Text)]
            [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
            public string Comentarios { get; set; }

        }

        public partial class PersonaLogMetadata
        {
            [Display(Name = "Nombre del cliente")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(50, ErrorMessage = "Máximo {1} caracteres")]
            public string Nombre { get; set; }

            [Display(Name = "Apellido")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(50, ErrorMessage = "Máximo {1} caracteres")]
            public string Apellido { get; set; }

            [Display(Name = "Cantidad de hermanos")]
            public int? Hermanos { get; set; }

            [Display(Name = "Fecha de nacimiento")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [DataType(DataType.Date)]
            public DateTime FechaDeNacimiento { get; set; }

            [Display(Name = "Persona")]
            public int IdPersona { get; set; }

            [Display(Name = "Dirección")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(50, ErrorMessage = "Máximo {1} caracteres")]
            public string Direccion { get; set; }


        }

        public partial class ProductoTipo
        {

            public int IdProductoTipo { get; set; }

            [Display(Name = "Descripción")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(50, ErrorMessage = "Máximo {1} caracteres")]
            public string Descripcion { get; set; }

            [Display(Name = "Nombre")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(50, ErrorMessage = "Máximo {1} caracteres")]
            public string Nombre { get; set; }

        }


        public partial class ComprasDetalleMetadata
        {

            public int IdComprasDetalle { get; set; }

            [Display(Name = "Descripción")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(50, ErrorMessage = "Máximo {1} caracteres")]
            public string Descripcion { get; set; }

        }

        public partial class FormaDePagoMetadata
        {
            public int Id { get; set; }

            [Display(Name = "Descripción")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(50, ErrorMessage = "Máximo {1} caracteres")]
            public string Descripción { get; set; }

            public virtual ICollection<Compras> Compras { get; set; }

            [Display(Name = "Estado")]
            [Required(ErrorMessage = "El campo {0} es obligatorio.")]
            [StringLength(50, ErrorMessage = "Máximo {1} caracteres")]
            public string Estado { get; set; }

        }


    }


   
}
