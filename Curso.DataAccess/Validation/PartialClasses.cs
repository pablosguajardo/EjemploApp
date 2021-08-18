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





    [ModelMetadataType(typeof(AspNetUsersMetadata))]
    public partial class AspNetUsers
    {
    }
}
