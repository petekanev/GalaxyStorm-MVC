namespace GalaxyStorm.Common.Tests.Mocks.Services
{
    using System;
    using System.Linq;
    using GalaxyStorm.Services.Data.Contracts;
    using Moq;

    public class BuildingsServiceMock
    {
        public static IBuildingsService Create()
        {
            var pO = MocksFactory.PlayerObjectsRepository.All().First();

            var service = new Mock<IBuildingsService>();
            service.Setup(s => s.GetPlayerBuildings(It.IsAny<string>())).Returns(pO.Buildings);


            return service.Object;
        }
    }
}
