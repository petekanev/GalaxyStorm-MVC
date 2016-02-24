namespace GalaxyStorm.Common.Tests.Mocks.Services
{
    using System;
    using System.Linq;
    using GalaxyStorm.Services.Data.Contracts;
    using Logic.Core;
    using Moq;

    public static class PlayerServiceMock
    {
        public static IPlayerService Create()
        {
            var pOs = MocksFactory.PlayerObjectsRepository;
            var logicProvider = new LogicProvider();

            var service = new Mock<IPlayerService>();
            service.Setup(s => s.GetPlayerInformation(It.IsAny<string>())).Returns(() => pOs.All().First());
            service.Setup(s => s.GetHourlyResourceIncome(It.IsAny<string>())).Returns(() =>
            {
                var user = pOs.All().First();
                var income = new long[3];

                var moreResourcesTechnology =
               logicProvider.Technologies.MoreResources.Modifier[user.Technologies.MoreResourcesLevel];
                var energyIncome =
                    logicProvider.Buildings.SolarCollector.ResourceGeneration[user.Buildings.SolarCollectorLevel];
                var crystalIncome =
                    logicProvider.Buildings.CrystalExtractor.ResourceGeneration[user.Buildings.CrystalExtractorLevel];
                var metalIncome =
                    logicProvider.Buildings.MetalScrapper.ResourceGeneration[user.Buildings.MetalScrapperLevel];

                income[0] = (long)(energyIncome + (energyIncome * moreResourcesTechnology));
                income[1] = (long)(crystalIncome + (crystalIncome * moreResourcesTechnology));
                income[2] = (long)(metalIncome + (metalIncome * moreResourcesTechnology));

                return income;
            });
            service.Setup(s => s.GetPlayerResources(It.IsAny<string>())).Returns(() => pOs.All().First().Resources);

            return service.Object;
        }
    }
}
