namespace GalaxyStorm.Common.Tests.Mocks.Services
{
    using System;
    using System.Linq;
    using GalaxyStorm.Services.Data.Contracts;
    using Moq;

    public class TechnologiesServiceMock
    {
        public static ITechnologiesService Create()
        {
            var pO = MocksFactory.PlayerObjectsRepository.All().First();

            var service = new Mock<ITechnologiesService>();
            service.Setup(s => s.GetPlayerTechnologies(It.IsAny<string>())).Returns(pO.Technologies);
            

            return service.Object;
        }
    }
}
