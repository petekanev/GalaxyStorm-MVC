using Microsoft.Owin;

[assembly: OwinStartup(typeof(GalaxyStorm.Web.Startup))]
namespace GalaxyStorm.Web
{
    using Hangfire;
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseHangfireDashboard();

            ConfigureAuth(app);
        }
    }
}
