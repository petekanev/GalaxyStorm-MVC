namespace GalaxyStorm.Common.Tests.Mocks.Services
{
    using System;
    using System.Linq.Expressions;
    using GalaxyStorm.Services.Data.Contracts;
    using GalaxyStorm.Services.Web.Contracts;
    using Moq;

    public class BackgroundWorkerMock
    {
        public static IBackgroundWorkerService<IService> Create()
        {
            var service = new Mock<IBackgroundWorkerService<IService>>();
            service.Setup(s => s.Schedule(It.IsAny<Expression<Action<IService>>>(), It.IsAny<TimeSpan>())).Verifiable();

            return service.Object;
        }
    }
}
