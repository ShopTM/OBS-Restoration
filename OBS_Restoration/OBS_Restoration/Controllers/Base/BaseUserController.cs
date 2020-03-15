using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAL.Managers;
using OBS_Restoration.Models;
using Common.Log;

namespace OBS_Restoration.Controllers.Base
{
    [SessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
    public class BaseUserController : Controller
    {
        private UserSignInManager _signInManager;
        private UsersManager _userManager;
        private long? currentUserId = null;

        /// <summary>
        /// Do not use this property in controller constructor
        /// </summary>
        public long CurrentUserId => (currentUserId ?? (currentUserId = User.Identity.GetUserId<long>())).Value;


        public UserSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<UserSignInManager>();
            }
            protected set
            {
                _signInManager = value;
            }
        }

        public UsersManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<UsersManager>();
            }
            protected set
            {
                _userManager = value;
            }
        }

        protected AjaxResponse<T> DoWithValidation<T>(Func<AjaxResponse<T>> onValid)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return onValid();
                }
                var errors = ModelState.Keys.SelectMany(x => ModelState[x].Errors);
                throw new Exception(string.Join(",", errors.Select(x => x.ErrorMessage)));
            }
            catch (Exception ex)
            {
                Logger.LogError("DoWithValidation " + ex.Message);

                return new AjaxResponse<T>
                {
                    Success = false,
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}