using Microsoft.Owin;

[assembly: OwinStartup(typeof(GalaxyStorm.Web.Startup))]
namespace GalaxyStorm.Web
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
