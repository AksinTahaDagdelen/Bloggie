using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Seed Roles (User,Amin,SuperAdmin)
            var adminRoleId = "9d4f7c72-3e2e-4127-81a8-373ede58fc80";
            var superAdminRoleId = "c51cb135-f6bc-4ad4-b004-fe553e4a1f3e";
            var userRoleId = "15717916-5056-411d-99f9-f95a67a636e0";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName ="Admin",
                    Id=adminRoleId,
                    ConcurrencyStamp = adminRoleId
                },
                    new IdentityRole
                {
                    Name = "SuperAdmin",
                    NormalizedName ="SuperAdmin",
                    Id=superAdminRoleId,
                    ConcurrencyStamp = superAdminRoleId
                },
                     new IdentityRole
                {
                    Name = "User",
                    NormalizedName ="User",
                    Id=userRoleId,
                    ConcurrencyStamp = userRoleId
                },
            };

            builder.Entity<IdentityRole>().HasData(roles);

            // Seed SuperAdministor

            var superAdminId = "c8c28db1-9787-4642-b762-d27ca5ecf37a";
            var superAdminUser = new IdentityUser
            {
                UserName = "superadmin@bloggie.com",
                Email = "superadmin@bloggie.com",
                NormalizedEmail = "superadmin@bloggie.com".ToUpper(),
                NormalizedUserName = "superadmin@bloggie.com".ToUpper(),
                Id = superAdminId
            };
            //superadmine şifre oluşturudğumuz alan
            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(superAdminUser, "Beyazcikolata@berkay123");

            builder.Entity<IdentityUser>().HasData(superAdminUser);

            //Add All Roles To SuperAdmin

            var superAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId= adminRoleId,
                    UserId = superAdminId
                },
                 new IdentityUserRole<string>
                {
                    RoleId= superAdminRoleId,
                    UserId = superAdminId
                },
                  new IdentityUserRole<string>
                {
                    RoleId= userRoleId,
                    UserId = superAdminId
                },


            };
            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
        }
    }
}
