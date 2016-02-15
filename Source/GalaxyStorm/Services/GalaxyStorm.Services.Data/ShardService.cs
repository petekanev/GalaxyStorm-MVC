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
        private IRepository<PlayerObject> players;

        public Shard GetShardByPlayerId(string userId)
        {
            //var pO = players.All().FirstOrDefault(x => x.)
            throw new NotImplementedException();
        }
    }
}
