using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using DAL;
using System;
using BAL.Managers;
using Models.Entities;
using Microsoft.AspNet.Identity.Owin;

[assembly: OwinStartup(typeof(OBS_Restoration.App_Start.Startup))]
namespace OBS_Restoration.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(DbContext.Create);
            app.CreatePerOwinContext<UsersManager>(UsersManager.Create);
            app.CreatePerOwinContext<UserSignInManager>(UserSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<UsersManager, User, long>(
                                validateInterval: TimeSpan.FromMinutes(5),
                                 regenerateIdentityCallback: (manager, user) => user.GenerateUserIdentityAsync(manager),
                                 getUserIdCallback: (id) => id.GetUserId<long>())
                }
            });
        }
    }
}