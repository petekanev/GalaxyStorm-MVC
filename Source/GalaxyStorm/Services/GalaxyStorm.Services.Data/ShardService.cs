namespace GalaxyStorm.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using GalaxyStorm.Data.Models;
    using GalaxyStorm.Data.Models.PlayerObjects;
    using GalaxyStorm.Data.Repositories;

    public class ShardService : IShardService
    {
        private readonly IRepository<PlayerObject> players;

        public ShardService(IRepository<PlayerObject> players)
        {
            this.players = players;
        }

        public Shard GetShardByPlayerId(string userId)
        {
            var pO = players.All().FirstOrDefault(x => x.ApplicationUserId == userId);

            if (pO == null)
            {
                return null;
            }

            return pO.Planet.Shard;
        }
    }
}
