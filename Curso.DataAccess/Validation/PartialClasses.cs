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

    [ModelMetadataType(typeof(ProveedoresMetadata))]
    public partial class Proveedores
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

    [ModelMetadataType(typeof(VentasDetalleMetadata))]
    public partial class VentasDetalle
    {
    }

    [ModelMetadataType(typeof(PersonaLog))]
    public partial class PersonaLog
    {
    }

    [ModelMetadataType(typeof(ClienteTipoMetadata))]
    public partial class ClienteTipo
    {
    }

    [ModelMetadataType(typeof(ComprasMetadata))]
    public partial class Compras
    {
    }


}
