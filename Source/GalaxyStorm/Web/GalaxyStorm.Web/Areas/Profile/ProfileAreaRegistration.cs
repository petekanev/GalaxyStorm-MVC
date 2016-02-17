using System.Web.Mvc;

namespace GalaxyStorm.Web.Areas.Profile
{
    public class ProfileAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Profile";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Profile_Area_Default",
                "Profile/{controller}/{action}/{id}",
                new { controller = "Preview", action = "Index", id = UrlParameter.Optional },
                new[] { "GalaxyStorm.Web.Areas.Profile.Controllers" });

            context.MapRoute(
                "Profile_default",
                "Profile/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "GalaxyStorm.Web.Areas.Profile.Controllers"}
            );
        }
    }
}