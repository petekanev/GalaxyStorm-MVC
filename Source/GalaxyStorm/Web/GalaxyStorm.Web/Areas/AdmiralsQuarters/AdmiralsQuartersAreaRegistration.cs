using System.Web.Mvc;

namespace GalaxyStorm.Web.Areas.AdmiralsQuarters
{
    public class AdmiralsQuartersAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdmiralsQuarters";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdmiralsQuarters_default",
                "AdmiralsQuarters/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}