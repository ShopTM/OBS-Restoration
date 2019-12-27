using Microsoft.AspNet.Identity;
using Models.Entities;
using System;
using System.Threading.Tasks;

namespace BAL.Identity
{
    public class IdentityUserManager : UserManager<User, long>
    {
        public IdentityUserManager(IUserStore<User, long> store) : base(store)
        {
            this.UserLockoutEnabledByDefault = false;
            // this.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(10);
            // this.MaxFailedAccessAttemptsBeforeLockout = 10;
            this.UserValidator = new UserValidator<User, long>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = false
            };

            // Configure validation logic for passwords
            this.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 4,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };
        }

        public override async Task<User> FindAsync(string userName, string password)
        {
            var user = await FindByNameAsync(userName);

            var isPasswordValid = await CheckPasswordAsync(user, password);

            if (isPasswordValid)
            {
                return user;
            }

            return null;
        }
    }
}
