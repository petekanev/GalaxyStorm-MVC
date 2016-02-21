namespace GalaxyStorm.Common.Tests.Mocks
{
    using Data.Models.PlayerObjects;
    using Data.Repositories;
    using GalaxyStorm.Services.Data.Contracts;
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
    }
}
