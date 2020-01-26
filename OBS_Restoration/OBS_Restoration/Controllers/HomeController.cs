using BAL.Managers;
using Common.Log;
using Models;
using Models.Entities;
using Models.VM.RequestForm;
using OBS_Restoration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace OBS_Restoration.Controllers
{
    public class HomeController : Controller
    {
        private const string SUCCESS_SENT_EMAIL_MESSAGE = "Email was send successfuly";
        private const string GENERAL_ERROR_MESSAGE = "An error has occurred during the processing of your request, please try again later.";
        private const string FAILED_VALIDATION_ERROR_MESSAGE = "Form validation is failed";

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
            var responce = new AjaxResponse<List<Service>>();
            try
            {
                responce.Data = _serviceManager.All(true);
                responce.Success = true;
            }
            catch (Exception e)
            {
                Logger.LogError("Get services" + e.Message);
                responce.ErrorMessage = GENERAL_ERROR_MESSAGE;
            }
            return Json(responce, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProjects()
        {
            var responce = new AjaxResponse<List<Project>>();
            try
            {
                responce.Data = _projectManager.All(true);
                responce.Success = true;
            }
            catch (Exception e)
            {
                Logger.LogError("Get projects" + e.Message);
                responce.ErrorMessage = GENERAL_ERROR_MESSAGE;
            }
            return Json(responce, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ContactUs(ContactRequestFormVM model)
        {
            var responce = new AjaxResponse<List<string>>();
            if (ModelState.IsValid)
            {
                try
                {
                    _emailManager.SendContactUsEmail(model);
                    responce.Success = true;
                    responce.Data.Add(SUCCESS_SENT_EMAIL_MESSAGE);
                }
                catch (Exception e)
                {
                    Logger.LogError("Contact Us email sending" + e.Message);
                    responce.ErrorMessage = GENERAL_ERROR_MESSAGE;
                }
            }
            responce.ErrorMessage = FAILED_VALIDATION_ERROR_MESSAGE;
            responce.Data.AddRange(ModelState.Values.SelectMany(v => v.Errors.Select(x => x.ErrorMessage)).ToList());

            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Careers(CareerRequestFormVM model)
        {
            var responce = new AjaxResponse<List<string>>();
            if (ModelState.IsValid)
            {
                try
                {
                    _emailManager.SendCareerEmail(model);
                    responce.Success = true;
                    responce.Data.Add(SUCCESS_SENT_EMAIL_MESSAGE);
                }
                catch (Exception e)
                {
                    Logger.LogError("Career request email sending" + e.Message);
                    responce.ErrorMessage = GENERAL_ERROR_MESSAGE;
                }
            }
            responce.ErrorMessage = FAILED_VALIDATION_ERROR_MESSAGE;
            responce.Data.AddRange(ModelState.Values.SelectMany(v => v.Errors.Select(x => x.ErrorMessage)).ToList());

            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult JobEstimation(JobEstimationRequestFormVM model)
        {
            var responce = new AjaxResponse<List<string>>();
            if (ModelState.IsValid)
            {
                try
                {
                    _emailManager.SendJobEstimationEmail(model);
                    responce.Success = true;
                    responce.Data.Add(SUCCESS_SENT_EMAIL_MESSAGE);
                }
                catch (Exception e)
                {
                    Logger.LogError("Job estimation request email sending" + e.Message);
                    responce.ErrorMessage = GENERAL_ERROR_MESSAGE;
                }
            }
            responce.ErrorMessage = FAILED_VALIDATION_ERROR_MESSAGE;
            responce.Data.AddRange(ModelState.Values.SelectMany(v => v.Errors.Select(x => x.ErrorMessage)).ToList());

            return Json(model, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}