using System.Web.Mvc;

namespace ACT.Areas.WorkPlanning
{
    public class WorkPlanningAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "WorkPlanning";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "WorkPlanning_default",
                "WorkPlanning/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}