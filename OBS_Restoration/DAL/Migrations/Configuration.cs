using System.Data.Entity.Migrations;

namespace DAL.Migrations
{
  

    internal sealed class Configuration : DbMigrationsConfiguration<GeneralDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.GeneralDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
