using System.Web.Mvc;

namespace ACT.Areas.SystemManagment
{
    public class SystemManagmentAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SystemManagment";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SystemManagment_default",
                "SystemManagment/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}