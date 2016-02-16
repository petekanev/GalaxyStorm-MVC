namespace GalaxyStorm.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using GalaxyStorm.Data.Models;

    public interface IShardService
    {
        Shard GetShardByPlayerId(string userId);

        void AllocatePlanets(Shard shard);

        void UpdateShard(Shard shard);

        IEnumerable<Shard> GetShards();
    }
}
