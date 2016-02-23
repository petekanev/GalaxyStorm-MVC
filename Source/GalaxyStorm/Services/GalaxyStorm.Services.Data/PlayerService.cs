namespace GalaxyStorm.Services.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Contracts;
    using GalaxyStorm.Data.Models;
    using GalaxyStorm.Data.Models.PlayerObjects;
    using GalaxyStorm.Data.Repositories;
    using Logic.Core;

    public class PlayerService : IPlayerService
    {
        private readonly IRepository<ApplicationUser> users;

        private readonly IRepository<Planet> planets;

        private readonly IRepository<Shard> shards;

        private readonly IRepository<PlayerObject> players;

        private readonly ILogicProvider logic;

        public PlayerService(IRepository<ApplicationUser> users, IRepository<Planet> planets, IRepository<Shard> shards, IRepository<PlayerObject> players, ILogicProvider logic)
        {
            this.users = users;
            this.planets = planets;
            this.shards = shards;
            this.players = players;
            this.logic = logic;
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

        public void AssignUnassignedUsers()
        {
            var unassignedUsers = this.users.All().Where(x => x.PlayerObject == null).ToList();

            foreach (var user in unassignedUsers)
            {
                AssignPlayerObject(user);
                this.users.Update(user);
                this.users.SaveChanges();

                AssignUserToPlayerObject(user.Id);
                AssignPlayerObjectToPlanet(user.Id);
            }
        }

        public void AssignPlayerObject(ApplicationUser user)
        {
            this.AssignPlayerObjectWithShard(user, -1);
        }

        public void AssignPlayerObjectWithShard(ApplicationUser user, int shardId)
        {
            var pO = new PlayerObject();

            pO.Units = new Units();

            pO.Buildings = new Buildings
            {
                HeadQuartersLevel = 1,
                BarracksLevel = 0,
                ResearchCentreLevel = 0,
                SolarCollectorLevel = 1,
                CrystalExtractorLevel = 1,
                MetalScrapperLevel = 1
            };

            // TODO: Extract into logic
            pO.Points = new Points
            {
                PointsCombat = 0,
                PointsNeutral = 0,
                PointsPlanet = (pO.Buildings.HeadQuartersLevel*100)
                               + (pO.Buildings.SolarCollectorLevel*10)
                               + (pO.Buildings.CrystalExtractorLevel*10)
                               + (pO.Buildings.MetalScrapperLevel*10)
            };

            // TODO: Extract into logic
            pO.Resources = new Resources
            {
                Energy = 350,
                Crystal = 350,
                Metal = 350
            };

            pO.Technologies = new Technologies();

            Planet planet;

            var shard = this.shards.All().FirstOrDefault(x => x.Id == shardId);

            if (shard != null)
            {
                planet = shard.Planets.Where(y => !y.IsPopulated)
                    .OrderBy(x => Guid.NewGuid())
                    .FirstOrDefault();
            }
            else
            {
                var randomShard = this.shards.All()
                    .Where(x => x.Planets.Any(p => !p.IsPopulated && !x.IsLocked))
                    .OrderBy(x => Guid.NewGuid())
                    .First();

                planet = randomShard.Planets.Where(y => !y.IsPopulated)
                    .OrderBy(x => Guid.NewGuid())
                    .FirstOrDefault();
            }

            planet.IsPopulated = true;

            planets.Update(planet);
            planets.SaveChanges();

            pO.PlanetId = planet.Id;

            user.PlayerObject = pO;
        }

        public void AssignUserToPlayerObject(string userId)
        {
            var user = this.users
                .All()
                .Include(x => x.PlayerObject)
                .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return;
            }

            var pO = user.PlayerObject;
            pO.ApplicationUserId = user.Id;

            this.players.Update(pO);
            this.players.SaveChanges();
        }

        public void AssignPlayerObjectToPlanet(string userId)
        {
            var user = this.users
                .All()
                .Include(x => x.PlayerObject)
                .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return;
            }

            var planet = user.PlayerObject.Planet;
            planet.PlayerObjectId = user.PlayerObjectId;

            this.planets.Update(planet);
            this.planets.SaveChanges();
        }

        public Resources GetPlayerResources(string userId)
        {
            var user = this.users
               .All()
               .Include(x => x.PlayerObject)
               .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return null;
            }

            return user.PlayerObject.Resources;
        }

        public long[] GetHourlyResourceIncome(string userId)
        {
            var user = this.users
                .All()
                .Include(x => x.PlayerObject)
                .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return null;
            }

            var resourcesIncome = new long[3];
            var moreResourcesTechnology =
                this.logic.Technologies.MoreResources.Modifier[user.PlayerObject.Technologies.MoreResourcesLevel];
            var energyIncome =
                this.logic.Buildings.SolarCollector.ResourceGeneration[user.PlayerObject.Buildings.SolarCollectorLevel];
            var crystalIncome =
                this.logic.Buildings.CrystalExtractor.ResourceGeneration[user.PlayerObject.Buildings.CrystalExtractorLevel];
            var metalIncome =
                this.logic.Buildings.MetalScrapper.ResourceGeneration[user.PlayerObject.Buildings.MetalScrapperLevel];

            resourcesIncome[0] = (long) (energyIncome + (energyIncome*moreResourcesTechnology));
            resourcesIncome[1] = (long) (crystalIncome + (crystalIncome*moreResourcesTechnology));
            resourcesIncome[2] = (long) (metalIncome + (metalIncome*moreResourcesTechnology));

            return resourcesIncome;
        }

        public PlayerObject GetPlayerInformation(string userId)
        {
            var user = this.users
                .All()
                .Include(x => x.PlayerObject)
                .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return null;
            }

            return user.PlayerObject;
        }

        public IQueryable<PlayerObject> GetPlayers()
        {
            return this.players.All();
        }

        public void UpdateResources(string poId, long energy, long crystal, long metal)
        {
            var pO = this.players.All().FirstOrDefault(x => x.Id.ToString() == poId);

            if (pO == null)
            {
                return;
            }

            pO.Resources.Energy = energy;
            pO.Resources.Crystal = crystal;
            pO.Resources.Metal = metal;

            this.players.Update(pO);
            this.players.SaveChanges();
        }
    }
}
