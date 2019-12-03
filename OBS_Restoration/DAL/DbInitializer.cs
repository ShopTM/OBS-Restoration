using DAL.Models;
using System.Data.Entity;

namespace DAL
{
    public class DbInitializer : DropCreateDatabaseAlways<GeneralDbContext>
    {
        protected override void Seed(GeneralDbContext db)
        {
            db.Roles.Add(new Role {  Name = "Admin" });
            db.Users.Add(new User
            {
                Email = "admin@gmail.com",
            });
            base.Seed(db);
        }
    }
}