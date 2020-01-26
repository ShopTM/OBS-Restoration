using DAL.Repositories.Interfaces;
using Models.Entities;
using System;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> UsersRepository { get; }

        IRepository<Role> RoleRepository { get; }
        IRepository<UserRole> UserRoleRepository { get; }
        IRepository<Service> ServiceRepository { get; }
        IRepository<Project> ProjectRepository { get; }
        IRepository<ProjectImage> ProjectImageRepository { get; }

        void ExecuteSqlCommand(string sql, params object[] parameters);
        void Commit();
        void Save();
    }
}
