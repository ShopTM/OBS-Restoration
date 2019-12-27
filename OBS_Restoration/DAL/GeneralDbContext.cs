using DAL.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace DAL
{
    public class GeneralDbContext: IdentityDbContext<User, Role, long, UserLogin, UserRole, UserClaim>
    {
        public GeneralDbContext()
            : base("GeneralDbContext")
        { }

        public DbSet<Service> Services { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectImage> ProjectImages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<UserRole>().ToTable("UserRoles");
            modelBuilder.Entity<UserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<UserLogin>().ToTable("UserLogins");
        }
    }
}
