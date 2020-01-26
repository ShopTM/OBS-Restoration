using Common;
using Common.Log;
using OBS_Restoration.Models;
using System;

namespace OBS_Restoration.Helpers
{
    public static class AjaxResponseHelper
    {
        public static AjaxResponse<T> AjaxMethodWrapper<T>(Func<T> method)
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
    }
}