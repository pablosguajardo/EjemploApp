using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Curso.Web.Models
{
    public class RoleEdit
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<IdentityUser> Members { get; set; }//original: IdentityUser extendido: AppUser
        public IEnumerable<IdentityUser> NonMembers { get; set; }//original: IdentityUser extendido: AppUser
    }
}
