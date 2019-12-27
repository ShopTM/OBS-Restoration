using Microsoft.AspNet.Identity.EntityFramework;
using Models.Entities;

namespace BAL.Identity
{
    public class IdentityUserStore : UserStore<User, Role, long, UserLogin, UserRole, UserClaim>
    {
        public IdentityUserStore(System.Data.Entity.DbContext context) : base(context)
        {
        }
    }
}
