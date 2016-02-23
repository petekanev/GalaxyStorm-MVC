namespace GalaxyStorm.Services.Data.Contracts
{
    using System.Linq;
    using GalaxyStorm.Data.Models.PlayerObjects;

    public interface IInfoService
    {
        IQueryable<PlayerObject> GetTopPlayersInShards(int topCount);

        IQueryable<PlayerObject> GetTopPlayersInSingleShard(int shardId, int topCount);
    }
}
