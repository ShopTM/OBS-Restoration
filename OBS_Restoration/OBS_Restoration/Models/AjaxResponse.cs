using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OBS_Restoration.Models
{
    public class AjaxResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public AjaxResponse()
        {

        }
        public AjaxResponse(T data)
        {
            Success = true;
            Data = data;
        }
    }
}