using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Models.VM;
using BAL.Managers;
using Common.Log;

namespace OBS_Restoration.Controllers
{
    [Authorize]
    public class ManageController : BaseController
    {
        public ManageController()
        {
        }

        public ManageController(UsersManager userManager, UserSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        //
        // GET: /Manage/Index
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.Error ? "An error has occurred."
                : "";

            var userId = User.Identity.GetUserId<long>();
            var user = await UserManager.FindByIdAsync(userId);
            var model = new IndexViewModel
            {
                HasPassword = true,
                Logins = await UserManager.GetLoginsAsync(userId),
                BrowserRemembered = await AuthenticationManager.TwoFactorBrowserRememberedAsync(userId.ToString())
            };
            return View(model);
        }
        //
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId<long>(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId<long>());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
            return View(model);
        }


        [HttpPost]
        public ActionResult EditUserInformation(string firstName, string lastName)
        {
            var user = UserManager.FindById(User.Identity.GetUserId<long>());
            var model = new IndexViewModel
            {
                HasPassword = true
            };
            try
            {
                if (user == null || (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName)))
                {
                    return RedirectToAction("Index", "Manage", model);
                }
            }
            catch (Exception ex)
            {
                Logger.LogErrorException("Cant edit user",ex);
            }
            return RedirectToAction("Index", "Manage", model);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            Error
        }

        #endregion
    }
}