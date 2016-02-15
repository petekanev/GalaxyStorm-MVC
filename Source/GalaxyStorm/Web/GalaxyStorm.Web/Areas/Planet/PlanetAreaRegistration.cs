using System.Web.Mvc;

namespace GalaxyStorm.Web.Areas.Planet
{
    public class PlanetAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Planet";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Planet_default",
                "Planet/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "GalaxyStorm.Web.Areas.Planet.Controllers"}
            );
        }
    }
}