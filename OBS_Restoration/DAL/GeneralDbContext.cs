using DAL.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL
{
    public class GeneralDbContext : IdentityDbContext<User>
    {
        public GeneralDbContext()
            : base("GeneralDbContext")
        { }
        public static GeneralDbContext Create()
        {
            return new GeneralDbContext();
        }

    public DbSet<Service> Services { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectImage> ProjectImages { get; set; }
    }
}
