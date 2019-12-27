using Microsoft.AspNet.Identity.EntityFramework;
using Models.Entities;
using System.Data.Entity;

namespace DAL
{
    public class DbContext : IdentityDbContext<User, Role, long, UserLogin, UserRole, UserClaim>
    {
        public DbContext() : base("DbContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            this.Database.CommandTimeout = 60 * 20;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<UserRole>().ToTable("UserRoles");
            modelBuilder.Entity<UserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<UserLogin>().ToTable("UserLogins");
        }
        public static DbContext Create()
        {
            return new DbContext();
        }

        public DbSet<Service> Services { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectImage> ProjectImages { get; set; }

    }
}