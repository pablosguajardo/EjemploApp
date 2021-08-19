using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static Curso.DataAccess.Validations.Metadata;


//Importante es el namespace:
namespace Curso.DataAccess.Models
{

    [ModelMetadataType(typeof(PersonasMetadata))]
    public partial class Personas
    {
    }
    [ModelMetadataType(typeof(CategoriaProductosMetadata))]
    public partial class CategoriaProductos
    {
    }
    [ModelMetadataType(typeof(ClientesLogMetadata))]
    public partial class ClientesLog
    {
    }

    [ModelMetadataType(typeof(ProductosMetadata))]
    public partial class Productos
    {
    }

    [ModelMetadataType(typeof(ProductoTipoMetadata))]
    public partial class ProductoTipo
    {
    }

    [ModelMetadataType(typeof(ProveedoresCategoriaMetadata))]
    public partial class ProveedoresCategoria
    {
    }

    [ModelMetadataType(typeof(AspNetUsersMetadata))]
    public partial class AspNetUsers
    {
    }

    [ModelMetadataType(typeof(VentasMetadata))]
    public partial class Ventas
    {
    }

<<<<<<< HEAD
    [ModelMetadataType(typeof(PersonaLog))]
    public partial class PersonaLog
    {
    }
=======
    [ModelMetadataType(typeof(VentasDetalleMetadata))]
    public partial class VentasDetalle
    {

    }

>>>>>>> dc30b4c72bdf2b0e2db5baca1f5fd27cb644f75d
}
