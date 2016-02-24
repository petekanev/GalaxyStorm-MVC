namespace GalaxyStorm.Controllers.Tests
{
    using System;
    using System.Reflection;
    using AutoMapper;
    using Data.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ViewModels.Common;
    using Web.App_Start;

    [TestClass]
    public class TestInit
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            AutoMapperConfig.RegisterMappings(Assembly.Load("GalaxyStorm.ViewModels"));
            Mapper.CreateMap<Planet, PlanetViewModel>();
        }
    }
}
