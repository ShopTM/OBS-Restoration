using DAL.Repositories.Interfaces;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> UsersRepository { get; }

        IRepository<Role> RoleRepository { get; }
        IRepository<UserRole> UserRoleRepository { get; }

        void ExecuteSqlCommand(string sql, params object[] parameters);
        void Commit();
        void Save();
    }
}
