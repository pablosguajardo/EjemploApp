using Curso.DataAccess.Validations;
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
}
