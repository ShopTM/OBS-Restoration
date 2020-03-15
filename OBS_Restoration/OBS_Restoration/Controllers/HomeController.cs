using BAL.Managers;
using Models;
using Models.VM.RequestForm;
using OBS_Restoration.Helpers;
using System.Web.Mvc;

namespace OBS_Restoration.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseAjaxController
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

        public ActionResult Projects()
        {
            return View();
        }

        public ActionResult Careers()
        {

            return View();
        }

        public ActionResult ContactUs()
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
            return ExecGetAjax(() => { return _serviceManager.All(true); });
        }
        public JsonResult GetProjects()
        {
            return ExecGetAjax(() => { return _projectManager.All(true); });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ContactUs(ContactRequestFormVM model)
        {
            return ExecPostAjax(() => { _emailManager.SendContactUsEmail(model); });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Careers(CareerRequestFormVM model)
        {
            return ExecPostAjax(() => { _emailManager.SendCareerEmail(model); });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult JobEstimation(JobEstimationRequestFormVM model)
        {
            return ExecPostAjax(() => { _emailManager.SendJobEstimationEmail(model); });
        }
        #endregion
    }
}