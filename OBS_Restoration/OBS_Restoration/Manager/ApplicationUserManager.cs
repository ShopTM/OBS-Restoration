using DAL;
using DAL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace OBS_Restoration.Manager
{
    public class ApplicationUserManager : UserManager<User,long>
    {
        public ApplicationUserManager(IUserStore<User, long> store)
                : base(store)
        {
        }
        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
                                                IOwinContext context)
        {
            GeneralDbContext db = context.Get<GeneralDbContext>();
            ApplicationUserManager manager = new ApplicationUserManager(new UserStore<User, Role, long, UserLogin, UserRole, UserClaim>(db));
            return manager;
        }
    }
}