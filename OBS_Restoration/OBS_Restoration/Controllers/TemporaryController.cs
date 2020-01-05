using BAL.Managers;
using Common.Log;
using Models;
using Models.Entities;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OBS_Restoration.Controllers
{
    [Authorize]
    public class TemporaryController : BaseController
    {
        public TemporaryController()
        {
        }
        public TemporaryController(UsersManager userManager, UserSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> CreateAdmin(string Email, string Password) // http://localhost:49195/Temporary/CreateAdmin?Email=email@email.com&Password=123456
        {
            try
            {
                var user = new User
                {
                    UserName = Email,
                    Email = Email,
                    UserType = UserType.Admin,
                };
                var us = UserManager.CreateUserWithRole(user, Password);
                if (us != false)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                Logger.LogErrorException("CreateAdmin", ex);
            }
            return RedirectToAction("Login");
        }
    }
}