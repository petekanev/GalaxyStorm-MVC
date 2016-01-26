using System.Web.Mvc;

namespace GalaxyStorm.Web.Areas.Shard
{
    public class ShardAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Shard";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Shard_default",
                "Shard/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}