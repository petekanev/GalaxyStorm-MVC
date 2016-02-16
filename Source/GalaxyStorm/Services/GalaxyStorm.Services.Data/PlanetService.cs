namespace GalaxyStorm.Services.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Contracts;
    using GalaxyStorm.Data.Models;
    using GalaxyStorm.Data.Models.PlayerObjects;
    using GalaxyStorm.Data.Repositories;

    public class PlanetService : IPlanetService
    {
        private readonly IRepository<ApplicationUser> users;   
        private readonly IRepository<PlayerObject> players;
        private readonly IRepository<Shard> shards;

        public PlanetService(IRepository<ApplicationUser> users, IRepository<PlayerObject> players, IRepository<Shard> shards)
        {
            this.users = users;
            this.players = players;
            this.shards = shards;
        }

        public Planet GetPublicPlanet(string userId, string shardName, string planetName)
        {
            var player = this.users
                .All()
                .Include(x => x.PlayerObject)
                .FirstOrDefault(u => u.Id == userId);

            if (player == null)
            {
                return null;
            }

            var shard =
                this.shards.All().FirstOrDefault(x =>x.Title == shardName);

            if (shard == null)
            {
                return null;
            }

            if (!this.IsAllowed(player.PlayerObject, shard))
            {
                return null;
            }

            var planet =
                shard.Planets.FirstOrDefault(x => x.Title == planetName);

            return planet;
        }

        private bool IsAllowed(PlayerObject player, Shard shard)
        {
            return player.Planet.ShardId == shard.Id;
        }
    }
}
