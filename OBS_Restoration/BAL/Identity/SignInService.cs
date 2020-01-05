using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Models.Entities;

namespace BAL.Identity
{
    public class SignInService: SignInManager<User, long>
    {
        public SignInService(IdentityUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }
        public static SignInService Create(IdentityFactoryOptions<SignInService> options, IOwinContext context)
        {
            return new SignInService(context.GetUserManager<IdentityUserManager>(), context.Authentication);
        }
    }
}
