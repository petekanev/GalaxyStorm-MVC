namespace GalaxyStorm.Web
{
    using System;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using App_Start;
    using Areas.Admiral;
    using Areas.Planet;
    using Areas.Profile;
    using Areas.Public;
    using Areas.Shard;
    using Utilities;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            DatabaseConfig.Initialize();
            //AreaRegistration.RegisterAllAreas();
            this.ManualAreaRegistration();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutofacConfig.Config();
            AutoMapperConfig.RegisterMappings(Assembly.Load("GalaxyStorm.ViewModels"));

            IntegrityCheck.EnsureIntegrity();

            HangfireBootstrapper.Instance.Start();

            HangfireJobConfig.ConfigureRecurringJobs();
        }

        protected void Application_End(object sender, EventArgs e)
        {
            HangfireBootstrapper.Instance.Stop();
        }

        private void ManualAreaRegistration()
        {
            var area1Reg = new AdmiralAreaRegistration();
            var area1Context = new AreaRegistrationContext(area1Reg.AreaName, RouteTable.Routes);
            area1Reg.RegisterArea(area1Context);

            var area2Reg = new ProfileAreaRegistration();
            var area2Context = new AreaRegistrationContext(area2Reg.AreaName, RouteTable.Routes);
            area2Reg.RegisterArea(area2Context);

            var area3Reg = new ShardAreaRegistration();
            var area3Context = new AreaRegistrationContext(area3Reg.AreaName, RouteTable.Routes);
            area3Reg.RegisterArea(area3Context);

            var area4Reg = new PlanetAreaRegistration();
            var area4Context = new AreaRegistrationContext(area4Reg.AreaName, RouteTable.Routes);
            area4Reg.RegisterArea(area4Context);

            //var area5Reg = new PublicAreaRegistration();
            //var area5Context = new AreaRegistrationContext(area5Reg.AreaName, RouteTable.Routes);
            //area5Reg.RegisterArea(area5Context);
        }
    }
}