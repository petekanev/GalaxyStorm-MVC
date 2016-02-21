namespace GalaxyStorm.Web.Routes.Tests
{
    using System.Net.Http;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Areas.Public;
    using Areas.Public.Controllers;
    using MvcRouteTester;
    using NUnit.Framework;

    [TestFixture]
    public class PublicAreaRouteTests
    {
        private RouteCollection routeCollection;

        [TestFixtureSetUp]
        public void RouteCollectionSetup()
        {
            var area5Reg = new PublicAreaRegistration();
            var area5Context = new AreaRegistrationContext(area5Reg.AreaName, RouteTable.Routes);
            area5Reg.RegisterArea(area5Context);

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            this.routeCollection = RouteTable.Routes;
        }

        [Test]
        public void TestDefaultPublicAreaRoute()
        {
            var url = "/";
            this.routeCollection.ShouldMap(url).To<HomeController>(c => c.Index());
        }

        [Test]
        public void TestAccountLoginRoute()
        {
            var url = "/Account/Login";
            this.routeCollection.ShouldMap(url).To<AccountController>(c => c.Login(null));
        }

        [Test]
        public void TestAccountRegisterRoute()
        {
            var url = "/Account/Register";
            this.routeCollection.ShouldMap(url).To<AccountController>(HttpMethod.Get, c => c.Register());
        }
    }
}
