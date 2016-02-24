namespace GalaxyStorm.Common.Tests.Mocks
{
    using Data.Models.PlayerObjects;
    using Data.Repositories;
    using GalaxyStorm.Services.Data.Contracts;
    using GalaxyStorm.Services.Web.Contracts;
    using Logic.Core;
    using Repositories;
    using Services;

    public class MocksFactory
    {
        public static IRepository<PlayerObject> PlayerObjectsRepository
        {
            get { return PlayerObjectsRepositoryMock.Create(); }
        }

        public static ILogicProvider LogicProvider
        {
            get { return LogicProviderMock.Create(); }
        }

        public static IPlayerService PlayerService
        {
            get { return PlayerServiceMock.Create(); }
        }

        public static IFleetService FleetService
        {
            get { return FleetServiceMock.Create(); }
        }

        public static IBackgroundWorkerService<IService> BackgroundWorkerService
        {
            get { return BackgroundWorkerMock.Create(); }
        }
    }
}
