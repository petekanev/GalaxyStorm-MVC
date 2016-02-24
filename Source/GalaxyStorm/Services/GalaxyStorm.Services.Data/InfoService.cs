namespace GalaxyStorm.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using GalaxyStorm.Data.Models.PlayerObjects;
    using GalaxyStorm.Data.Repositories;

    public class InfoService : IInfoService
    {
        private readonly IRepository<PlayerObject> players;

        public InfoService(IRepository<PlayerObject> players)
        {
            this.players = players;
        }

        public IQueryable<PlayerObject> GetTopPlayersInShards(int topCount)
        {
            return
                players.All()
                    .OrderByDescending(x => (x.Points.PointsCombat + x.Points.PointsNeutral + x.Points.PointsPlanet))
                    .Take(topCount);
        }

        public IQueryable<PlayerObject> GetTopPlayersInSingleShard(int shardId, int topCount)
        {
            return players.All()
                .Where(x => x.Planet.ShardId == shardId)
                .OrderByDescending(x => (x.Points.PointsCombat + x.Points.PointsNeutral + x.Points.PointsPlanet))
                    .Take(topCount);
        }

        public IQueryable<PlayerObject> GetTopPlayersWithCombatPoints(int topCount)
        {
            return players.All()
                .OrderByDescending(x => x.Points.PointsCombat)
                .Take(topCount);
        }

        public IQueryable<PlayerObject> GetTopPlayersWithNeutralPoints(int topCount)
        {
            return players.All()
                .OrderByDescending(x => x.Points.PointsNeutral)
                .Take(topCount);
        }

        public IQueryable<PlayerObject> GetTopPlayerWithPlanetPoints(int topCount)
        {
            return players.All()
                .OrderByDescending(x => x.Points.PointsPlanet)
                .Take(topCount);
        }
    }
}
