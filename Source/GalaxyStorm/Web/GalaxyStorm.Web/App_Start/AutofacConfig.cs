namespace GalaxyStorm.Web.App_Start
{
    using System.Web.Mvc;
    using Autofac;
    using Autofac.Integration.Mvc;
    using Modules;

    public class AutofacConfig
    {
        public static void Config()
        {
            //Autofac Configuration
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();

            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new EfModule());

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}