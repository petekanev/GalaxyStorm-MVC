﻿namespace GalaxyStorm.Web.Modules
{
    using System.Reflection;
    using Autofac;
    using Module = Autofac.Module;

    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("GalaxyStorm.Services.Data"))
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}