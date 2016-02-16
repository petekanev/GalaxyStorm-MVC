namespace GalaxyStorm.Web.App_Start
{
    using System.Linq;
    using Data;
    using Data.Models;
    using Data.Models.PlayerObjects;
    using Data.Repositories;
    using Services.Data;
    using Services.Data.Contracts;

    public class IntegrityCheck
    {
        public static void EnsureIntegrity()
        {
            var ctx = new GalaxyStormDbContext();
            var shardsRepo = new Repository<Shard>(ctx);
            var playersRepo = new Repository<PlayerObject>(ctx);
            var usersRepo = new Repository<ApplicationUser>(ctx);
            var planetsRepo = new Repository<Planet>(ctx);

            var shardService = new ShardService(playersRepo, shardsRepo);
            var playerService = new PlayerService(usersRepo,planetsRepo, shardsRepo, playersRepo, null);

            AllocatePlanets(shardService);

            AssignPlayerObjects(playerService);
        }

        private static void AllocatePlanets(IShardService shardService)
        {
            var allShards = shardService.GetShards().ToList();

            foreach (var shard in allShards)
            {
                if (shard.Planets.Count <= 1)
                {
                    shardService.AllocatePlanets(shard);
                }
            }
        }

        private static void AssignPlayerObjects(IPlayerService playerService)
        {
            playerService.AssignUnassignedUsers();
        }
    }
}