namespace GalaxyStorm.Web.Routes.Tests
{
    using System;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Areas.Profile;
    using Areas.Profile.Controllers;
    using MvcRouteTester;
    using NUnit.Framework;

    [TestFixture]
    public class ProfileAreaRouteTests
    {
        private RouteCollection routeCollection;

        [TestFixtureSetUp]
        public void RouteCollectionSetup()
        {
            var area2Reg = new ProfileAreaRegistration();
            var area2Context = new AreaRegistrationContext(area2Reg.AreaName, RouteTable.Routes);
            area2Reg.RegisterArea(area2Context);

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            this.routeCollection = RouteTable.Routes;
        }

        [TestFixtureTearDown]
        public void RouteCollectionDestroy()
        {
            RouteTable.Routes.Clear();
        }

        [Test]
        public void TestDefaultProfileAreaRoute()
        {
            var url = "/Profile";
            this.routeCollection.ShouldMap(url).To<PreviewController>(c => c.Index());
        }

        [Test]
        public void TestDefaultReportsRoute()
        {
            var url = "/Profile/Reports";
            this.routeCollection.ShouldMap(url).To<ReportsController>(c => c.Index());
        }

        [Test]
        public void TestReportDetailsRoute()
        {
            var reportId = 42;
            var url = "/Profile/Reports/Details/{0}/";
            this.routeCollection.ShouldMap(string.Format(url, reportId)).To<ReportsController>(c => c.Details(42));
        }

        [Test]
        public void TestManageIndexRoute()
        {
            var url = "/Profile/Manage";
            this.routeCollection.ShouldMap(url).To<ManageController>(c => c.Index(null));
        }

        [Test]
        public void TestManageChangePasswordRoute()
        {
            var url = "/Profile/Manage/ChangePassword";
            this.routeCollection.ShouldMap(url).To<ManageController>(c => c.ChangePassword());
        }
    }
}
