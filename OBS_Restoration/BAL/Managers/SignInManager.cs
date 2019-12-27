using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Models.Entities;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BAL.Managers
{
    public class UserSignInManager : SignInManager<User, long>
    {
        public UserSignInManager(UsersManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            return user.GenerateUserIdentityAsync((UsersManager)UserManager);
        }

        public static UserSignInManager Create(IdentityFactoryOptions<UserSignInManager> options, IOwinContext context)
        {
            return new UserSignInManager(context.GetUserManager<UsersManager>(), context.Authentication);
        }
    }
}
