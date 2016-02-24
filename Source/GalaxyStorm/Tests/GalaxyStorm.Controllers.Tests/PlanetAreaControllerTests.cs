namespace GalaxyStorm.Controllers.Tests
{
    using System;
    using AutoMapper;
    using Common.Tests.Mocks;
    using Data.Models;
    using Logic.Core;
    using NUnit.Framework;
    using TestStack.FluentMVCTesting;
    using ViewModels.Common;
    using Web.Areas.Planet.Controllers;

    [TestFixture]
    public class PlanetAreaControllerTests
    {
        private PreviewController previewController;

        [TestFixtureSetUp]
        public void PlanetAreaControllerTestsSetup()
        {
            var serviceMock = MocksFactory.PlayerService;
            var logic = new LogicProvider();

            this.previewController = new PreviewController(serviceMock, logic);

            Mapper.CreateMap<Planet, PlanetViewModel>();
        }

        [Test]
        public void PreviewIndexShouldWorkCorrectly()
        {
            const int expectedBarracksLevel = 8;
            const int expectedCELevel = 13;
            const int expectedHQLevel = 13;
            const int expectedMSLevel = 12;
            const int expectedRCLevel = 4;
            const int expectedSCLevel = 13;

            this.previewController.WithCallTo(x => x.Index())
                .ShouldRenderDefaultView()
                .WithModel<CompletePlayerViewModel>(
                    vM =>
                    {
                        Assert.AreEqual(expectedBarracksLevel, vM.Buildings.Barracks.Level);
                        Assert.AreEqual(expectedCELevel, vM.Buildings.CrystalExtractor.Level);
                        Assert.AreEqual(expectedHQLevel, vM.Buildings.Headquarters.Level);
                        Assert.AreEqual(expectedMSLevel, vM.Buildings.MetalScrapper.Level);
                        Assert.AreEqual(expectedRCLevel, vM.Buildings.ResearchCentre.Level);
                        Assert.AreEqual(expectedSCLevel, vM.Buildings.SolarCollector.Level);
                    }).AndNoModelErrors();
        }

        [Test]
        public void PreviewIndexShouldWorkCorrectlyWithFleetNumbers()
        {
            const int expectedScouts = 100;
            const int expectedCarriers = 110;
            const int expectedFighters = 100;

            this.previewController.WithCallTo(x => x.Index())
                .ShouldRenderDefaultView()
                .WithModel<CompletePlayerViewModel>(
                    vM =>
                    {
                        Assert.AreEqual(expectedScouts, vM.Fleet.Scout.AmountOnPlanet);
                        Assert.AreEqual(expectedCarriers, vM.Fleet.Carrier.AmountOnPlanet);
                        Assert.AreEqual(expectedFighters, vM.Fleet.Fighter.AmountOnPlanet);
                        Assert.AreEqual(0, vM.Fleet.Bomber.AmountOnPlanet);
                        Assert.AreEqual(0, vM.Fleet.Interceptor.AmountOnPlanet);
                        Assert.AreEqual(0, vM.Fleet.Juggernaut.AmountOnPlanet);
                    }).AndNoModelErrors();
        }

        [Test]
        public void PreviewResourcesChildActionShouldWorkCorrectly()
        {
            this.previewController.WithCallToChild(x => x.Resources())
                .ShouldRenderView("_Resources").WithModel<ResourcesViewModel>(
                    vM =>
                    {
                        Assert.IsTrue(vM.Metal == 1000);
                        Assert.IsTrue(vM.Energy == 1000);
                        Assert.IsTrue(vM.Crystal == 1000);
                        Assert.IsTrue(vM.CrystalPerHour > 100);
                        Assert.IsTrue(vM.EnergyPerHour > 100);
                        Assert.IsTrue(vM.MetalPerHour > 100);
                    })
                .AndNoModelErrors();
        }
    }
}
