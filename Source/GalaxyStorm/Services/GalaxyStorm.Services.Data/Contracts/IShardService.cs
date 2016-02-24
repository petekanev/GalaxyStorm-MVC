namespace GalaxyStorm.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GalaxyStorm.Data.Models;

    public interface IShardService : IService
    {
        Shard GetShardByPlayerId(string userId);

        void AllocatePlanets(Shard shard);

        void UpdateShard(Shard shard);

        IQueryable<Shard> GetShards();
    }
}
