using DAL.Models;
using System.Web.Mvc;

namespace OBS_Restoration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(/*RegisterViewModel model*/)
        {
            if (ModelState.IsValid)
            {
                //var user = new User { UserName = model.Email, Email = model.Email };
                //var result = await UserManager.CreateAsync(user, model.Password);
                //if (result.Succeeded)
                //{
                //    await UserManager.AddToRoleAsync(user.Id, "user");
                //    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                //    return RedirectToAction("Index", "Home");
                //}
                //AddErrors(result);
            }

            return View(/*model*/);
        }


        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}