using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsuariosApi.Data
{
    public class UserDBContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        private IConfiguration _configuration;

        public UserDBContext(DbContextOptions<UserDBContext> opt, IConfiguration configuration) : base(opt)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            IdentityUser<int> admin = new IdentityUser<int>
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = 99999
            };

            // criptografar a nova senha
            PasswordHasher<IdentityUser<int>> hasher = new PasswordHasher<IdentityUser<int>>();

            // usar string que é menos seguro ou secrets
            // admin.PasswordHash = hasher.HashPassword(admin, "Admin123!"); 
            admin.PasswordHash = hasher.HashPassword(admin, _configuration.GetValue<string>("admininfo:password"));

            // buildar o dado
            builder.Entity<IdentityUser<int>>().HasData(admin); 

            // Role Admin
            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 99999, Name = "admin", NormalizedName = "ADMIN" }
            );

            // Role Regular
            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 99998, Name = "regular", NormalizedName = "REGULAR" }
            );

            // Vincular Role Admin ao Usuario Admin
            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { RoleId = 99999, UserId = 99999 }
            );
        }
    }
}
