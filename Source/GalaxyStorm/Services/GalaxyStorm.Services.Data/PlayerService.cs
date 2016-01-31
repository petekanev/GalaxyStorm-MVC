namespace GalaxyStorm.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using GalaxyStorm.Data;
    using GalaxyStorm.Data.Models;
    using GalaxyStorm.Data.Models.PlayerObjects;
    using GalaxyStorm.Data.Models.PlayerObjects.BuildingsComplexTypes;
    using GalaxyStorm.Data.Repositories;
    using Logic.Core;

    public class PlayerService : IPlayerService
    {
        private readonly IRepository<ApplicationUser> users;

        private readonly IRepository<Planet> planets;

        private readonly IRepository<Shard> shards;

        public PlayerService(IRepository<ApplicationUser> users, IRepository<Planet> planets, IRepository<Shard> shards)
        {
            this.users = users;
            this.planets = planets;
            this.shards = shards;
        }

        public void ReassignPlayerObject(string userId)
        {
            var user = this.users
                .All()
                .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return;
            }

            this.AssignPlayerObject(user);
        }

        public void AssignPlayerObject(ApplicationUser user)
        {
            this.AssignPlayerObjectWithShard(user, -1);
        }

        public void AssignPlayerObjectWithShard(ApplicationUser user, int shardId)
        {
            var pO = new PlayerObject();

            pO.Units = new Units
            {
                BomberQuantity = 0,
                CarriersQuantity = 0,
                DispatchedBombers = 0,
                DispatchedCarriers = 0,
                DispatchedFighters = 0,
                DispatchedInterceptors = 0,
                DispatchedJuggernauts = 0,
                DispatchedScouts = 0,
                FighterQuantity = 0,
                InterceptorQuantiy = 0,
                JuggernautQuantity = 0,
                ScoutsQuantity = 0
            };

            pO.Buildings = new Buildings();
            pO.Buildings.HeadQuarters = new HeadQuarters { Level = 1 };
            pO.Buildings.Barracks = new Barracks { Level = 0 };
            pO.Buildings.ResearchCentre = new ResearchCentre { Level = 0 };
            pO.Buildings.SolarCollector = new SolarCollector { Level = 1 };
            pO.Buildings.CrystalExtractor = new CrystalExtractor { Level = 1 };
            pO.Buildings.MetalScrapper = new MetalScrapper { Level = 1 };

            pO.Points = new Points();
            pO.Points.PointsCombat = 0;
            pO.Points.PointsNeutral = 0;
            pO.Points.PointsPlanet = (pO.Buildings.HeadQuarters.Level * 100)
                + (pO.Buildings.SolarCollector.Level * 10)
                + (pO.Buildings.CrystalExtractor.Level * 10)
                + (pO.Buildings.MetalScrapper.Level * 10);

            pO.Resources = new Resources();
            pO.Resources.Energy = 350;
            pO.Resources.Crystal = 350;
            pO.Resources.Metal = 350;

            pO.Technologies = new Technologies();
            pO.Technologies.ArmorFleetLevel = 0;
            pO.Technologies.CheaperFleetLevel = 0;
            pO.Technologies.FasterConstructionLevel = 0;
            pO.Technologies.LargerFleetLevel = 0;
            pO.Technologies.MoreResourcesLevel = 0;

            Planet planet;

            var shard = this.shards.All().FirstOrDefault(x => x.Id == shardId);

            if (shard != null)
            {
                pO.ShardId = shard.Id;

                planet = shard.Planets.Where(y => !y.IsPopulated)
                    .OrderBy(x => Guid.NewGuid())
                    .FirstOrDefault();
            }
            else
            {
                var randomShard = this.shards.All()
                    .Where(x => x.Planets.Any(p => !p.IsPopulated))
                    .OrderBy(x => Guid.NewGuid())
                    .First();

                pO.ShardId = randomShard.Id;

                planet = randomShard.Planets.Where(y => !y.IsPopulated)
                    .OrderBy(x => Guid.NewGuid())
                    .FirstOrDefault();
            }

            planet.IsPopulated = true;

            pO.PlanetId = planet.Id;

            user.PlayerObject = pO;
        }
    }
}
