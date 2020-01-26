using BAL.Managers;
using Common;
using Common.Log;
using Models.Entities;
using OBS_Restoration.Helpers;
using OBS_Restoration.Models;
using System;
using System.Collections.Generic;
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
            _emailManager = new EmailManager();
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
        public JsonResult GetServices()
        {
            var responce = AjaxResponseHelper.AjaxMethodWrapper(() => { return _serviceManager.All(); });
            return Json(responce, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetService(int id)
        {
            var responce = AjaxResponseHelper.AjaxMethodWrapper(() => { return _serviceManager.GetService(id); });
            return Json(responce, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProjects()
        {
            var responce = AjaxResponseHelper.AjaxMethodWrapper(() => { return _projectManager.All(); });
            return Json(responce, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProject(int id)
        {
            var responce = AjaxResponseHelper.AjaxMethodWrapper(() => { return _projectManager.GetProject(id); });
            return Json(responce, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}