namespace GalaxyStorm.Controllers.Tests
{
    using System;
    using Common.Tests.Mocks;
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
            var logicMock = MocksFactory.LogicProvider;

            this.previewController = new PreviewController(serviceMock, logicMock);
        }

        [Test]
        public void PreviewIndexShouldWorkCorrectly()
        {
            this.previewController.WithCallTo(x => x.Index())
                .ShouldRenderDefaultView()
                .WithModel<CompletePlayerViewModel>(
                    vM =>
                    {

                    }).AndNoModelErrors();
        }

        [Test]
        public void PreviewResourcesShouldWorkCorrectly()
        {
            this.previewController.WithCallToChild(x => x.Resources())
                .ShouldRenderView("_Resources").WithModel<ResourcesViewModel>(
                    vM =>
                    {

                    })
                .AndNoModelErrors();

        }
    }
}
