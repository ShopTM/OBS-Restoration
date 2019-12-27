using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class UserLogin : IdentityUserLogin<long>
    {
    }

    public class UserRole : IdentityUserRole<long>
    {
    }

    public class UserClaim : IdentityUserClaim<long>
    {
    }

    public class Role : IdentityRole<long, UserRole>
    {
        public Role():base()
        {
        }
        public Role(string name) : base()
        {
            this.Name = name;
        }
    }

    public class User : IdentityUser<long, UserLogin, UserRole, UserClaim>, IUser<long>
    {
        public UserType UserType { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, long> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
