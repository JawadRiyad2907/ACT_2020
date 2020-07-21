using ACT.Authentication;
using ACT.Utilities.Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ACT.Controllers
{
    public class BaseController : Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            ViewBag.Version = DateTime.Now.ToString("yyyyMMdd");
            base.Initialize(requestContext);
        }

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string cultureName = null;
            // Attempt to read the culture cookie from Request
            HttpCookie cultureCookie = Request.Cookies["_culture"];
            if (cultureCookie != null)
            {
                cultureName = cultureCookie.Value;
            }
            else
            {
                cultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0 ?
                        Request.UserLanguages[0] :  // obtain it from HTTP header AcceptLanguages
                        null;
            }
            // Validate culture name
            cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe
            CultureInfo kCulture = new CultureInfo(cultureName);
            kCulture.DateTimeFormat = CultureInfo.CreateSpecificCulture("en").DateTimeFormat;
            kCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            kCulture.DateTimeFormat.LongDatePattern = "dd/MM/yyyy";
            Thread.CurrentThread.CurrentCulture = kCulture;
            Thread.CurrentThread.CurrentUICulture = kCulture;
            return base.BeginExecuteCore(callback, state);
        }

        protected override void OnException(ExceptionContext filterContext)
        {

            //handel error log by elmah
            Elmah.ErrorSignal.FromCurrentContext().Raise(filterContext.Exception);

            //return view error
            var result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml",

            };

            //get sql error code
            var sqlException = filterContext.Exception.GetBaseException() as SqlException;
            if (sqlException != null)
            {
                result.ViewBag.ErrorNumber = sqlException.Number;
            }
            filterContext.ExceptionHandled = true;
            filterContext.Result = result;
        }

        public ActionResult SetCulture(string culture)
        {
            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);
            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            //return to current page
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActPrincipal CurrentUser
        {
            get
            {
                return (ActPrincipal)HttpContext.User;
            }
        }
    }
}