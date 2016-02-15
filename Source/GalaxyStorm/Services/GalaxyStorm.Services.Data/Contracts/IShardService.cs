namespace GalaxyStorm.Services.Data.Contracts
{
    using System;
    using GalaxyStorm.Data.Models;

    public interface IShardService
    {
        Shard GetShardByPlayerId(string userId);
    }
}
