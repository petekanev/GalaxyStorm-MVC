namespace GalaxyStorm.Common.Tests.Mocks
{
    using Data.Models.PlayerObjects;
    using Data.Repositories;
    using Repositories;

    public class MocksFactory
    {
        public static IRepository<PlayerObject> PlayerObjectsRepository
        {
            get { return PlayerObjectsRepositoryMock.Create(); }
        }
    }
}
