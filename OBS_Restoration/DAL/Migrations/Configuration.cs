using DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<GeneralDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GeneralDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            if (!context.Roles.Any(u => u.Name == Consts.Roles.Admin))
            {
                context.Set<Role>().Add(new Role(Consts.Roles.Admin));
            }

            var adminUser = new User
            {
                UserName = "Admin",
                Email = "Email@email.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            if (!context.Users.Any(u => u.UserName == adminUser.UserName))
            {
                var password = new PasswordHasher<User>();
                var hashed = password.HashPassword(adminUser, "123");
                adminUser.PasswordHash = hashed;
                context.Set<User>().AddOrUpdate(adminUser);

                context.SaveChanges();
                var roleId = context.Set<Role>().FirstOrDefault(x => x.Name == Consts.Roles.Admin).Id;
                context.Set<UserRole>().AddOrUpdate(new UserRole { RoleId = roleId,UserId = adminUser.Id });
            }

            context.SaveChanges();
        }
    }
}
