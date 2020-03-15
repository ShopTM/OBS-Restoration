using BAL.Managers;
using Common.Log;
using Models;
using Models.Entities;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OBS_Restoration.Controllers
{
#if DEBUG
    [AllowAnonymous]
    public class LocalController : BaseUserController
    {
        public LocalController()
        {
        }
        public LocalController(UsersManager userManager, UserSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        public JsonResult Index()
        {
            return Json("Local controller is avilable",JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public async Task<ActionResult> CreateAdmin(string email, string password) // http://localhost:49195/Local/CreateAdmin?Email=email@email.com&Password=123456
        {
            try
            {
                var user = new User
                {
                    UserName = email,
                    Email = email,
                    UserType = UserType.Admin,
                };
                var us = UserManager.CreateUserWithRole(user, password);
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
#endif
}