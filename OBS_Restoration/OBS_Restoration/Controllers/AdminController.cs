using BAL.Managers;
using Models.Entities;
using Models.VM.Service;
using OBS_Restoration.Helpers;
using System.Web;
using System.Web.Mvc;
using OBS_Restoration.Controllers.Base;
using Models.VM.Project;

namespace OBS_Restoration.Controllers
{
    [Authorize]
    public class AdminController : BaseAjaxController
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
        #region Service Ajax Methods
        public JsonResult GetServices()
        {
            return ExecGetAjax(() => { return _serviceManager.All(); });
        }
        public JsonResult GetService(int id)
        {
            return ExecGetAjax(() => { return _serviceManager.GetService(id); });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UpdateService(ServiceVM source)
        {
            return ExecPostAjax(() => { _serviceManager.UpdateService(source); });
        }
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteService(int id)
        {
            return ExecDeleteAjax(() => { _serviceManager.DeleteService(id); });
        }
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteBatchServices(int[] ids)
        {
            return ExecDeleteAjax(() => { _serviceManager.DeleteBatchServices(ids); });
        }
        #endregion
        #region Project Ajax Methods
        public JsonResult GetProjects()
        {
            return ExecGetAjax(() => { return _projectManager.All(); });
        }
        public JsonResult GetProject(int id)
        {
            return ExecGetAjax(() => { return _projectManager.GetProject(id); });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UpdateProject(ProjectVM source)
        {
            return ExecPostAjax(() => { _projectManager.UpdateProject(source); });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UploadProjectImage(ProjectImageVM image)
        {
            return ExecPostAjax(() => { _projectManager.UploadProjectImage(image); });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteProjectImage(int id)
        {
            return ExecDeleteAjax(() => { _projectManager.DeleteProjectImage(id); });
        }
        #endregion
    }
}