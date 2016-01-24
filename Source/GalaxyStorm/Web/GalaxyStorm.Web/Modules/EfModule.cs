namespace GalaxyStorm.Web.Modules
{
    using Autofac;
    using Data;
    using Data.Repositories;

    public class EfModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(GalaxyStormDbContext)).As(typeof(IGalaxyStormDbContext)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
        }
    }
}