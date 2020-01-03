using Models;
using Models.Entities;
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
    }
}
