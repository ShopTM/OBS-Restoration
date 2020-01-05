using DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Models.Entities;
using System;

namespace BAL.Managers
{
    public class UsersManager : UserManager<User, long>
    {
        public UsersManager(IUserStore<User, long> store)
            : base(store)
        {
        }
        public bool IsUserLocked(string login)
        {
            using (var db = DbFactory.GetInstance())
            {
                return db.UsersRepository.Any(u => u.Email.Equals(login) && u.LockoutEnabled == false);
            }
        }
        public bool CreateUserWithRole(User user, string password)
        {
            using (var db = DbFactory.GetInstance())
            {
                var enabledUser = user.LockoutEnabled;
                var result = this.Create(user, password);
                if (result.Succeeded)
                {
                    var roleId = db.RoleRepository.Get(r => r.Name.Equals(user.UserType.ToString()), r => r.Id);
                    var userRole = new UserRole { RoleId = roleId, UserId = user.Id };
                    db.UserRoleRepository.Add(userRole);
                    user.LockoutEnabled = enabledUser;
                    db.UsersRepository.Update(user);
                    db.Save();
                    return true;
                }
                return false;
            }

        }
        public static UsersManager Create(IdentityFactoryOptions<UsersManager> options, IOwinContext context)
        {
            var manager = new UsersManager(new UserStore<User, Role, long, UserLogin, UserRole, UserClaim>(context.Get<DbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<User, long>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 4
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<User, long>(dataProtectionProvider.Create("ASP.NET Identity OBS"));
            }
            return manager;
        }

    }
}
