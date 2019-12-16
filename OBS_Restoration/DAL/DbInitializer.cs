using DAL.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace DAL
{
    public class DbInitializer : DropCreateDatabaseAlways<GeneralDbContext>
    {
        protected override void Seed(GeneralDbContext db)
        {
            var user = new User
            {
                UserName = "Email@email.com",
                Email = "Email@email.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var roleStore = new RoleStore<IdentityRole>(db);

            if (!db.Roles.Any(r => r.Name == "admin"))
            {
                roleStore.CreateAsync(new IdentityRole { Name = "admin" });
            }

            if (!db.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<User>();
                var hashed = password.HashPassword(user, "password");
                user.PasswordHash = hashed;
                var userStore = new UserStore<User>(db);
                userStore.CreateAsync(user);
                userStore.AddToRoleAsync(user, "admin");
            }

            db.SaveChanges();
        }
    }
}