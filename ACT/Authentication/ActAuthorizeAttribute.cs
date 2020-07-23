using ACT.Utilities.Enum;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ACT.Authentication
{
    public class ActAuthorizeAttribute : AuthorizeAttribute
    {

        private readonly MenuEnum _menuEnum;
        private readonly OptionalAccessEnum _optionalAccessEnum;
        private string _resourceMessage;
        public ActAuthorizeAttribute(MenuEnum menuEnum, OptionalAccessEnum optionalAccessEnum = OptionalAccessEnum.Empty)
        {
            this._menuEnum = menuEnum;
            this._optionalAccessEnum = optionalAccessEnum;
        }


        protected virtual ActPrincipal CurrentUser
        {
            get
            {
                return HttpContext.Current.User as ActPrincipal;
            }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            


            if ((CurrentUser == null || (!CurrentUser.MenuIdsPermission.Contains((int)_menuEnum) && _menuEnum != MenuEnum.CommonAction)))
            {
                _resourceMessage = LocalizedText.Error_AccessDenied;
                return false;
            }
            else
            {
                return OptionalAccess(_optionalAccessEnum);
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            RedirectToRouteResult routeData = null;

            if (CurrentUser == null)
            {
                string retutnURL = "";
                if (filterContext.HttpContext.Request != null)
                {
                    retutnURL = filterContext.HttpContext.Request
                                                            .Url
                                                            .AbsoluteUri;
                }


                routeData = new RedirectToRouteResult
                    (new System.Web.Routing.RouteValueDictionary
                    (new
                    {
                        controller = "Account",
                        Action = "Login",
                        ReturnURL = retutnURL,
                        area = ""
                    }
                    ));
            }
            else
            {
                
                routeData = new RedirectToRouteResult
                (new System.Web.Routing.RouteValueDictionary
                 (new
                 {
                     controller = "Account",
                     Action = "AccessDenied",
                     area = "",
                 }
                 ));
                 
            }


            filterContext.Controller.TempData["ResourceMessage"] = _resourceMessage;
            filterContext.Result = routeData;
        }



        private bool OptionalAccess(OptionalAccessEnum optionalAccessEnum)
        {
            bool resualt = true;

            if (optionalAccessEnum != OptionalAccessEnum.Empty)
            {
                switch (optionalAccessEnum)
                {
                    case OptionalAccessEnum.IsDirectResponsible:
                        if (CurrentUser.LevelResponsibleForMe == null)
                        {
                            _resourceMessage = LocalizedText.Error_AccessDenied_Manager;
                            resualt = false;
                        }
                        break;
                }
            }
            return resualt;
        }
    }
}