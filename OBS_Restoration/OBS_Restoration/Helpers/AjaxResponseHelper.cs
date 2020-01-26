using Common;
using Common.Log;
using OBS_Restoration.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace OBS_Restoration.Helpers
{
    public static class AjaxResponseHelper
    {
        public static AjaxResponse<T> AjaxGetMethodWrapper<T>(Func<T> method)
        {
            var responce = new AjaxResponse<T>();
            try
            {
                responce.Data = method();
                responce.Success = true;
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                responce.ErrorMessage = ErrorMessages.GENERAL_ERROR_MESSAGE;
            }
            return responce;
        }
        public static AjaxResponse<string> AjaxUpdateMethodWrapper(Action method, ModelStateDictionary modelState)
        {
            var responce = new AjaxResponse<string>();
            if (modelState.IsValid)
            {
                try
                {
                    method();
                    responce.Success = true;
                    responce.Data = ErrorMessages.SUCCESS_SENT_EMAIL_MESSAGE;
                }
                catch (Exception e)
                {
                    Logger.LogError(e.Message);
                    responce.ErrorMessage = ErrorMessages.GENERAL_ERROR_MESSAGE;
                }
            }
            else
            {
                responce.ErrorMessage = ErrorMessages.FAILED_VALIDATION_ERROR_MESSAGE;
                responce.ValidationMessages = modelState.Where(x => x.Value.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );
            }
            return responce;
        }
    }
}