namespace GalaxyStorm.Web.App_Start
{
    using System.Web.Mvc;
    using Autofac;
    using Autofac.Integration.Mvc;
    using Hangfire;
    using Logic.Core;
    using Modules;
    using Services.Data;

    public class AutofacConfig
    {
        public static void Config()
        {
            //Autofac Configuration
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();

            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new EfModule());
            builder.RegisterType(typeof(LogicProvider)).As(typeof(ILogicProvider)).InstancePerLifetimeScope();

            // hangfire requires that these be manually bound
            builder.RegisterType<BuildingService>().InstancePerBackgroundJob();
            builder.RegisterType<TechnologiesService>().InstancePerBackgroundJob();
            builder.RegisterType<FleetService>().InstancePerBackgroundJob();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalConfiguration.Configuration.UseAutofacActivator(container);
        }
    }
}
