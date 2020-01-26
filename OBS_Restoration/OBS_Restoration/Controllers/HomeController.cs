using BAL.Managers;
using Models;
using Models.VM.RequestForm;
using OBS_Restoration.Helpers;
using System.Web.Mvc;

namespace OBS_Restoration.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly EmailManager _emailManager;
        private readonly ServiceManager _serviceManager;
        private readonly ProjectManager _projectManager;
        public HomeController()
        {
            _emailManager = new EmailManager();
            _serviceManager = new ServiceManager();
            _projectManager = new ProjectManager();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Suppliers()
        {
            return View();
        }

        public ActionResult Projects()
        {
            return View();
        }

        public ActionResult Careers()
        {

            return View();
        }

        public ActionResult Contacts()
        {
            return View();
        }
        public ActionResult Clients(ClientType type)
        {
            ViewBag.ClientType = type.ToString();
            return View();
        }
        public ActionResult Gallery()
        {
            return View();
        }

        #region Ajax methods
        public JsonResult GetServices()
        {
            var responce = AjaxResponseHelper.AjaxGetMethodWrapper(() => { return _serviceManager.All(true); });
            return Json(responce, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProjects()
        {
            var responce = AjaxResponseHelper.AjaxGetMethodWrapper(() => { return _projectManager.All(true); });
            return Json(responce, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ContactUs(ContactRequestFormVM model)
        {
            var responce = AjaxResponseHelper.AjaxUpdateMethodWrapper(() => { _emailManager.SendContactUsEmail(model); }, ModelState);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Careers(CareerRequestFormVM model)
        {
            var responce = AjaxResponseHelper.AjaxUpdateMethodWrapper(() => { _emailManager.SendCareerEmail(model); }, ModelState);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult JobEstimation(JobEstimationRequestFormVM model)
        {
            var responce = AjaxResponseHelper.AjaxUpdateMethodWrapper(() => { _emailManager.SendJobEstimationEmail(model); }, ModelState);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}