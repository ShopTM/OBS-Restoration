using BAL.Managers;
using Common;
using Common.Log;
using Models.Entities;
using OBS_Restoration.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OBS_Restoration.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly EmailManager _emailManager;
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
            var responce = new AjaxResponse<List<Service>>();
            try
            {
                responce.Data = _serviceManager.All();
                responce.Success = true;
            }
            catch (Exception e)
            {
                Logger.LogError("Get services" + e.Message);
                responce.ErrorMessage = ErrorMessages.GENERAL_ERROR_MESSAGE;
            }
            return Json(responce, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetService(int id)
        {
            var responce = new AjaxResponse<Service>();
            try
            {
                responce.Data = _serviceManager.GetService(id);
                responce.Success = true;
            }
            catch (Exception e)
            {
                Logger.LogError("Get service" + e.Message);
                responce.ErrorMessage = ErrorMessages.GENERAL_ERROR_MESSAGE;
            }
            return Json(responce, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProjects()
        {
            var responce = new AjaxResponse<List<Project>>();
            try
            {
                responce.Data = _projectManager.All();
                responce.Success = true;
            }
            catch (Exception e)
            {
                Logger.LogError("Get projects" + e.Message);
                responce.ErrorMessage = ErrorMessages.GENERAL_ERROR_MESSAGE;
            }
            return Json(responce, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetProject(int id)
        {
            var responce = new AjaxResponse<Project>();
            try
            {
                responce.Data = _projectManager.GetProject(id);
                responce.Success = true;
            }
            catch (Exception e)
            {
                Logger.LogError("Get project" + e.Message);
                responce.ErrorMessage = ErrorMessages.GENERAL_ERROR_MESSAGE;
            }
            return Json(responce, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}