using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Models.Entities;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        protected DbContext context;
        public IRepository<User> UsersRepository => new GenericRepository<User>(context);
        public IRepository<Role> RoleRepository => new GenericRepository<Role>(context);
        public IRepository<UserRole> UserRoleRepository => new GenericRepository<UserRole>(context);
        public IRepository<Service> ServiceRepository => new GenericRepository<Service>(context);
        public IRepository<Project> ProjectRepository => new GenericRepository<Project>(context);
        public IRepository<ProjectImage> ProjectImageRepository => new GenericRepository<ProjectImage>(context);

        public UnitOfWork(bool detectChanges)
        {
            this.context = new DbContext();
            context.Configuration.AutoDetectChangesEnabled = detectChanges;
        }

        public void ExecuteSqlCommand(string sql, params object[] parameters)
        {
            context.Database.ExecuteSqlCommand(sql, parameters);
        }

        /// <summary>
        /// Save changes in scope of Transaction
        /// </summary>
        public void Commit()
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// Save entire changes
        /// </summary>
        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }
    }
}
