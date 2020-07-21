using System.Web.Mvc;

namespace ACT.Areas.Level
{
    public class LevelAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Level";
            }
        } 


        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Level_default",
                "Level/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}