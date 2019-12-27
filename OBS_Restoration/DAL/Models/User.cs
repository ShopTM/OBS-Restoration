using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace DAL.Models
{
    public class UserLogin : IdentityUserLogin<long> {}

    public class UserRole : IdentityUserRole<long> { }

    public class UserClaim : IdentityUserClaim<long> { }

    public class Role : IdentityRole<long, UserRole> {
        public Role() : base()
        {
        }
        public Role(string name) : base()
        {
            this.Name = name;
        }
    }

    public class User : IdentityUser<long, UserLogin, UserRole, UserClaim>{ }
}
