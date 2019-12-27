using Models;
using Models.Entities;
using System;
using Microsoft.AspNetCore.Identity;
using System.Data.Entity.Migrations;
using System.Linq;


namespace DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.DbContext context)
        {
            SeedRoles(context);
            SeedUsers(context);
        }
        private static void SeedRoles(DAL.DbContext context)
        {
            if (!context.Roles.Any(x => x.Name == UserType.Admin.ToString()))
            {
                context.Roles.AddOrUpdate(new Role { Name = UserType.Admin.ToString() });
            }
            if (!context.Roles.Any(x => x.Name == UserType.LevelI.ToString()))
            {
                context.Roles.AddOrUpdate(new Role { Name = UserType.LevelI.ToString() });
            }
            if (!context.Roles.Any(x => x.Name == UserType.LevelII.ToString()))
            {
                context.Roles.AddOrUpdate(new Role { Name = UserType.LevelII.ToString() });
            }
            if (!context.Roles.Any(x => x.Name == UserType.LevelIII.ToString()))
            {
                context.Roles.AddOrUpdate(new Role { Name = UserType.LevelIII.ToString() });
            }
            context.SaveChanges();
        }
        private static void SeedUsers(DAL.DbContext context)
        {
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
                var hashed = password.HashPassword(adminUser, "123456");
                adminUser.PasswordHash = hashed;
                context.Set<User>().AddOrUpdate(adminUser);

                context.SaveChanges();
                var roleId = context.Set<Role>().FirstOrDefault(x => x.Name == UserType.Admin.ToString()).Id;
                context.Set<UserRole>().AddOrUpdate(new UserRole { RoleId = roleId, UserId = adminUser.Id });
            }

            context.SaveChanges();
        }
    }
}
