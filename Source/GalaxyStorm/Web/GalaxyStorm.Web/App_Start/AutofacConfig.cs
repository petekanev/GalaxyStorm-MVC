namespace GalaxyStorm.Web.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;
    using Autofac;
    using Autofac.Integration.Mvc;
    using Hangfire;
    using Infrastructure;
    using Logic.Core;
    using Modules;
    using Services.Web;
    using Services.Web.Contracts;

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

            builder.RegisterGeneric(typeof(BackgroundWorkerService<>)).As(typeof(IBackgroundWorkerService<>)).InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AssignableTo<BaseController>().PropertiesAutowired();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalConfiguration.Configuration.UseAutofacActivator(container);
        }
    }
}
