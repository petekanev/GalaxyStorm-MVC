namespace GalaxyStorm.Common.Tests.Mocks.Services
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using GalaxyStorm.Services.Data.Contracts;
    using Logic.Core;
    using Moq;

    public class FleetServiceMock
    {
        public static IFleetService Create()
        {
            var pOs = MocksFactory.PlayerObjectsRepository;
            var logicProvider = new LogicProvider();

            var service = new Mock<IFleetService>();

            service.Setup(s => s.GetPlayerFleet(It.IsAny<string>()))
                .Returns(pOs.All().First().Units);
            service.Setup(s => s.ScheduleRecruitBomber(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(() => null);
            service.Setup(s => s.ScheduleRecruitScout(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(() => TimeSpan.FromMinutes(5));
            service.Setup(s => s.ScheduleRecruitCarrier(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(() => TimeSpan.FromMinutes(5));
            service.Setup(s => s.ScheduleRecruitFighter(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(() => TimeSpan.FromMinutes(5));
            service.Setup(s => s.ScheduleRecruitInterceptor(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(() => null);
            service.Setup(s => s.ScheduleRecruitJuggernaut(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(() => null);

            service.Setup(s => s.CompleteRecruiting(It.IsAny<string>())).Verifiable();
            return service.Object;
        }
    }
}
