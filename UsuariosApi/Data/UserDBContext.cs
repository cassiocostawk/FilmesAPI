using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsuariosApi.Data
{
    public class UserDBContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public UserDBContext(DbContextOptions<UserDBContext> opt) : base(opt)
        {

        }
    }
}
