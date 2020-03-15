using OBS_Restoration.Helpers;
using System;
using System.Web.Mvc;

namespace OBS_Restoration.Controllers.Base
{
    public class BaseAjaxController : Controller
    {
        public JsonResult ExecGetAjax<T>(Func<T> method)
        {
            var responce = AjaxResponseHelper.AjaxGetWrapper(() => { return method(); });
            return Json(responce, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ExecPostAjax(Action method)
        {
            var responce = AjaxResponseHelper.AjaxPostWrapper(() => { method(); }, ModelState);
            return Json(responce, JsonRequestBehavior.DenyGet);
        }
        public JsonResult ExecDeleteAjax(Action method)
        {
            var responce = AjaxResponseHelper.AjaxDeleteWrapper(() => { method(); });
            return Json(responce, JsonRequestBehavior.DenyGet);
        }
    }
}