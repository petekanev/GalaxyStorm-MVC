﻿namespace GalaxyStorm.Web.Routes.Tests
{
    using System.Net.Http;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Areas.Planet;
    using Areas.Planet.Controllers;
    using MvcRouteTester;
    using NUnit.Framework;

    [TestFixture]
    public class PlanetAreaRouteTests
    {
        private RouteCollection routeCollection;

        [TestFixtureSetUp]
        public void RouteCollectionSetup()
        {
            var area4Reg = new PlanetAreaRegistration();
            var area4Context = new AreaRegistrationContext(area4Reg.AreaName, RouteTable.Routes);
            area4Reg.RegisterArea(area4Context);

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            this.routeCollection = RouteTable.Routes;
        }

        [Test]
        public void TestDefaultPlanetAreaRoute()
        {
            var url = "/Planet";
            this.routeCollection.ShouldMap(url).To<PreviewController>(c => c.Index());
        }

        [Test]
        public void TestDefaultPlanetBuildingsRoute()
        {
            var url = "/Planet/Buildings";
            this.routeCollection.ShouldMap(url).To<BuildingsController>(c => c.Index());
        }

        [Test]
        public void TestPlanetBuildingsResearchCentreRoute()
        {
            var url = "/Planet/Buildings/ResearchCentre";
            this.routeCollection.ShouldMap(url).To<BuildingsController>(c => c.ResearchCentre());
        }

        [Test]
        public void TestDefaultPlanetTechnologiesRoute()
        {
            var url = "/Planet/Technologies";
            this.routeCollection.ShouldMap(url).To<TechnologiesController>(c => c.Index());
        }

        [Test]
        public void TestDefaultPlanetFleetRoute()
        {
            var url = "/Planet/Fleet";
            this.routeCollection.ShouldMap(url).To<FleetController>(c => c.Index());
        }

        [Test]
        public void TestPlanetFleetJuggernautRoute()
        {
            var url = "/Planet/Fleet/Juggernaut";
            this.routeCollection.ShouldMap(url).To<FleetController>(c => c.Juggernaut());
        }

        [Test]
        public void TestPlanetTechnologiesPostRoute()
        {
            var url = "/Planet/Technologies/UpgradeMoreResources";
            this.routeCollection.ShouldMap(url).To<TechnologiesController>(HttpMethod.Post, c => c.UpgradeMoreResources());
        }

        [Test]
        public void TestPlanetBuildingsPostRoute()
        {
            var url = "/Planet/Buildings/UpgradeHeadquarters";
            this.routeCollection.ShouldMap(url).To<BuildingsController>(HttpMethod.Post, c => c.UpgradeHeadquarters());
        }

        [Test]
        public void TestPlanetFleetPostRoute()
        {
            var url = "/Planet/Fleet/RecruitBombers";
            var amount = 237;
            this.routeCollection.ShouldMap(url).WithJsonBody(string.Format("{{ 'amount': {0} }}", amount)).To<FleetController>(HttpMethod.Post, c => c.RecruitBombers(amount));
        }
    }
}
