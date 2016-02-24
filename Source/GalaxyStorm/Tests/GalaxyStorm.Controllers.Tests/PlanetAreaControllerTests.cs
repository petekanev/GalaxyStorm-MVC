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
    using ViewModels.Fleet;
    using Web.Areas.Planet.Controllers;

    [TestFixture]
    public class PlanetAreaControllerTests
    {
        private PreviewController previewController;
        private FleetController fleetController;
        private LogicProvider logic;

        [TestFixtureSetUp]
        public void PlanetAreaControllerTestsSetup()
        {
            var playerService = MocksFactory.PlayerService;
            var buildingsService = MocksFactory.BuildingsService;
            var technologiesService = MocksFactory.TechnologiesService;
            var fleetService = MocksFactory.FleetService;
            var worker = MocksFactory.BackgroundWorkerServiceFleet;
            logic = new LogicProvider();

            this.previewController = new PreviewController(playerService, logic);
            this.fleetController = new FleetController(playerService, buildingsService, fleetService, technologiesService, logic, worker);

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

        [Test]
        public void FleetControllerIndexActionShouldWorkCorrectly()
        {
            const int expectedScouts = 100;
            const int expectedCarriers = 110;
            const int expectedFighters = 100;
            const int expectedBarracksLevel = 8;

            this.fleetController.WithCallTo(c => c.Index())
                .ShouldRenderDefaultView()
                .WithModel<FleetViewModel>(
                    vM =>
                    {
                        Assert.AreEqual(expectedScouts, vM.Scout.AmountOnPlanet);
                        Assert.AreEqual(expectedCarriers, vM.Carrier.AmountOnPlanet);
                        Assert.AreEqual(expectedFighters, vM.Fighter.AmountOnPlanet);
                        Assert.AreEqual(0, vM.Bomber.AmountOnPlanet);
                        Assert.AreEqual(0, vM.Interceptor.AmountOnPlanet);
                        Assert.AreEqual(0, vM.Juggernaut.AmountOnPlanet);
                        Assert.AreEqual(expectedBarracksLevel, vM.BarracksLevel);
                    }
                ).AndNoModelErrors();
        }

        [Test]
        public void FleetControllerScoutActionShouldRenderCorrectResults()
        {
            this.fleetController.WithCallTo(c => c.Scout())
                .ShouldRenderDefaultView()
                .WithModel<UnitViewModel>(
                vM =>
                    {
                        Assert.AreEqual(0, vM.AmountOnPlanet);
                        Assert.AreEqual(0, vM.AmountDispatched);
                        Assert.AreEqual(this.logic.Ships.Scout.Attack, vM.Attack);
                        Assert.AreEqual(this.logic.Ships.Scout.Armor, vM.Armor);
                        Assert.AreEqual(this.logic.Ships.Scout.CargoCapacity, vM.CargoCapacity);
                        Assert.AreEqual(this.logic.Ships.Scout.Description, vM.Description);
                        Assert.AreEqual(this.logic.Ships.Scout.Name, vM.Name);
                        Assert.AreEqual(this.logic.Ships.Scout.PointsOnKill, vM.PointsOnKill);
                        Assert.AreEqual(this.logic.Ships.Scout.PointsOnRecruit, vM.PointsOnRecruit);
                        Assert.AreEqual(this.logic.Ships.Scout.Prerequisite, vM.Prerequisite);
                }).AndNoModelErrors();
        }

        [Test]
        public void FleetControllerFighterActionShouldRenderCorrectResults()
        {
            this.fleetController.WithCallTo(c => c.Scout())
                .ShouldRenderDefaultView()
                .WithModel<UnitViewModel>(
                vM =>
                {
                    Assert.AreEqual(0, vM.AmountOnPlanet);
                    Assert.AreEqual(0, vM.AmountDispatched);
                    Assert.AreEqual(this.logic.Ships.Fighter.Attack, vM.Attack);
                    Assert.AreEqual(this.logic.Ships.Fighter.Armor, vM.Armor);
                    Assert.AreEqual(this.logic.Ships.Fighter.CargoCapacity, vM.CargoCapacity);
                    Assert.AreEqual(this.logic.Ships.Fighter.Description, vM.Description);
                    Assert.AreEqual(this.logic.Ships.Fighter.Name, vM.Name);
                    Assert.AreEqual(this.logic.Ships.Fighter.PointsOnKill, vM.PointsOnKill);
                    Assert.AreEqual(this.logic.Ships.Fighter.PointsOnRecruit, vM.PointsOnRecruit);
                    Assert.AreEqual(this.logic.Ships.Fighter.Prerequisite, vM.Prerequisite);
                }).AndNoModelErrors();
        }

        [Test]
        public void FleetControllerBomberActionShouldRenderCorrectResults()
        {
            this.fleetController.WithCallTo(c => c.Scout())
                .ShouldRenderDefaultView()
                .WithModel<UnitViewModel>(
                vM =>
                {
                    Assert.AreEqual(0, vM.AmountOnPlanet);
                    Assert.AreEqual(0, vM.AmountDispatched);
                    Assert.AreEqual(this.logic.Ships.Bomber.Attack, vM.Attack);
                    Assert.AreEqual(this.logic.Ships.Bomber.Armor, vM.Armor);
                    Assert.AreEqual(this.logic.Ships.Bomber.CargoCapacity, vM.CargoCapacity);
                    Assert.AreEqual(this.logic.Ships.Bomber.Description, vM.Description);
                    Assert.AreEqual(this.logic.Ships.Bomber.Name, vM.Name);
                    Assert.AreEqual(this.logic.Ships.Bomber.PointsOnKill, vM.PointsOnKill);
                    Assert.AreEqual(this.logic.Ships.Bomber.PointsOnRecruit, vM.PointsOnRecruit);
                    Assert.AreEqual(this.logic.Ships.Bomber.Prerequisite, vM.Prerequisite);
                }).AndNoModelErrors();
        }
    }
}
