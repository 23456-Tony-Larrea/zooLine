using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Identity.Controllers
{
    public   class RoleEdit
    {
        public IdentityRole Role { get; set; }
        public List<IdentityUser> Members { get; set; }
        public List<IdentityUser> NonMembers { get; set; }
    }
}