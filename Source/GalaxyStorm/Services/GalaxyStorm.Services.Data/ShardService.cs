namespace GalaxyStorm.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Hosting;
    using Contracts;
    using GalaxyStorm.Data.Models;
    using GalaxyStorm.Data.Models.PlayerObjects;
    using GalaxyStorm.Data.Repositories;

    public class ShardService : IShardService
    {
        private readonly IRepository<PlayerObject> players;
        private readonly IRepository<Shard> shards;

        public ShardService(IRepository<PlayerObject> players, IRepository<Shard> shards)
        {
            this.players = players;
            this.shards = shards;
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

        public void AllocatePlanets(Shard shard)
        {
            var shardName = System.IO.File.ReadAllLines(HostingEnvironment.MapPath(@"~/App_Data/ShardNames.txt")).OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            var planetNames = System.IO.File.ReadAllLines(HostingEnvironment.MapPath(@"~/App_Data/PlanetNames.txt")).OrderBy(x => Guid.NewGuid()).ToList();

            shard.Title = shardName;

            var maxRows = 5;
            var maxCols = 5;

            switch (shard.ShardSize)
            {
                case ShardSize.Medium:
                    maxRows = 7;
                    maxCols = 7;
                    break;
                case ShardSize.Large:
                    maxRows = 10;
                    maxCols = 10;
                    break;
                case ShardSize.Gigantic:
                    maxRows = 15;
                    maxCols = 15;
                    break;
                default:
                    break;
            }

            var random = new Random();

            var xOffset = random.Next(-100, 750);
            var yOffset = random.Next(-100, 750);
            var titlesHash = new HashSet<string>();

            for (int i = 0; i < maxRows; i++)
            {
                for (int j = 0; j < maxCols; j++)
                {
                    if (random.Next(0, 101) <= 50)
                    {
                        var title = planetNames[random.Next(0, planetNames.Count)];
                        if (titlesHash.Contains(title))
                        {
                            j--;
                            continue;
                        }

                        titlesHash.Add(title);

                        var planet = new Planet
                        {
                            X = j + xOffset,
                            Y = i + yOffset,
                            Title = title,
                            EnergyModifier = 1,
                            CrystalModifier = 1,
                            MetalModifier = 1
                        };

                        shard.Planets.Add(planet);
                    }
                }
            }
            
            this.shards.Update(shard);
            this.shards.SaveChanges();
        }

        public IQueryable<Shard> GetShards()
        {
            return this.shards.All();
        }

        public void UpdateShard(Shard shard)
        {
            this.shards.Update(shard);
            this.shards.SaveChanges();
        }
    }
}
