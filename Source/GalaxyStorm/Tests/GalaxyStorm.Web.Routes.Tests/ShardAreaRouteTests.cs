namespace GalaxyStorm.Web.Routes.Tests
{
    using System;
    using System.Net.Http;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Areas.Shard;
    using Areas.Shard.Controllers;
    using MvcRouteTester;
    using NUnit.Framework;

    [TestFixture]
    public class ShardAreaRouteTests
    {
        private RouteCollection routeCollection;

        [TestFixtureSetUp]
        public void RouteCollectionSetup()
        {
            var area3Reg = new ShardAreaRegistration();
            var area3Context = new AreaRegistrationContext(area3Reg.AreaName, RouteTable.Routes);
            area3Reg.RegisterArea(area3Context);

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            this.routeCollection = RouteTable.Routes;
        }

        [TestFixtureTearDown]
        public void RouteCollectionDestroy()
        {
            RouteTable.Routes.Clear();
        }

        [Test]
        public void TestDefaultShardAreaRoute()
        {
            var url = "/Shard";
            this.routeCollection.ShouldMap(url).To<PreviewController>(HttpMethod.Get, c => c.Index());
        }

        [Test]
        public void TestDefaultPlanetDetailsRoute()
        {
            var shard = "ShardName";
            var planet = "PlanetName";
            var url = "/Shard/Planet/{0}/{1}";
            this.routeCollection.ShouldMap(string.Format(url, shard, planet)).To<PlanetController>(HttpMethod.Get, c => c.Index(shard, planet));
        }
    }
}
