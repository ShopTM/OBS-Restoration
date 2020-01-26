using BAL.Managers;
using Models.Entities;
using OBS_Restoration.Helpers;
using System.Web;
using System.Web.Mvc;

namespace OBS_Restoration.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ServiceManager _serviceManager;
        private readonly ProjectManager _projectManager;
        public AdminController()
        {
            _serviceManager = new ServiceManager();
            _projectManager = new ProjectManager();
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Projects()
        {
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }
        #region Ajax methods
        //Services
        public JsonResult GetServices()
        {
            var responce = AjaxResponseHelper.AjaxGetMethodWrapper(() => { return _serviceManager.All(); });
            return Json(responce, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetService(int id)
        {
            var responce = AjaxResponseHelper.AjaxGetMethodWrapper(() => { return _serviceManager.GetService(id); });
            return Json(responce, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UpdateService(Service source)
        {
            var responce = AjaxResponseHelper.AjaxUpdateMethodWrapper(() => { _serviceManager.UpdateService(source); }, ModelState);
            return Json(responce, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UploadServiceImage(int id, HttpPostedFileBase img)
        {
            //todo: add validation for file
            var responce = AjaxResponseHelper.AjaxUpdateMethodWrapper(() => { _serviceManager.UploadServiceImage(id, img); }, ModelState);
            return Json(responce, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteServiceImage(int id)
        {
            var responce = AjaxResponseHelper.AjaxUpdateMethodWrapper(() => { _serviceManager.DeleteServiceImage(id); }, ModelState);
            return Json(responce, JsonRequestBehavior.AllowGet);
        }
        //Projects
        public JsonResult GetProjects()
        {
            var responce = AjaxResponseHelper.AjaxGetMethodWrapper(() => { return _projectManager.All(); });
            return Json(responce, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProject(int id)
        {
            var responce = AjaxResponseHelper.AjaxGetMethodWrapper(() => { return _projectManager.GetProject(id); });
            return Json(responce, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UpdateProject(Project source)
        {
            var responce = AjaxResponseHelper.AjaxUpdateMethodWrapper(() => { _projectManager.UpdateProject(source); }, ModelState);
            return Json(responce, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UploadProjectImage(int id,int order, HttpPostedFileBase img)
        {
            //todo: add validation for file
            var responce = AjaxResponseHelper.AjaxUpdateMethodWrapper(() => { _projectManager.UploadProjectImage(id, order, img); }, ModelState);
            return Json(responce, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteProjectImage(int id)
        {
            var responce = AjaxResponseHelper.AjaxUpdateMethodWrapper(() => { _projectManager.DeleteProjectImage(id); }, ModelState);
            return Json(responce, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}