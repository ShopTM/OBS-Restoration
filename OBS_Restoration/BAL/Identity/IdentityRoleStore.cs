using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Models.Entities;

namespace BAL.Identity
{
    public class IdentityRoleStore : RoleStore<Role, long, UserRole>
    {
        public IdentityRoleStore(DbContext context) : base(context)
        {
        }
    }
}
