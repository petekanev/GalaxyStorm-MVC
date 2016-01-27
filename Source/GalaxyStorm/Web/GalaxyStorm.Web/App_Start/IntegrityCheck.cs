namespace GalaxyStorm.Web.App_Start
{
    using System;
    using System.Linq;
    using Data;
    using Data.Models;
    using Data.Repositories;
    using Logic.Core;
    using Utilities;

    public class IntegrityCheck
    {
        public static void EnsureIntegrity()
        {
            var logicProvider = new LogicProvider();

            var ctx = new GalaxyStormDbContext();

            var shards = new Repository<Shard>(ctx);
            var users = new Repository<ApplicationUser>(ctx);

            var allShards = shards.All().ToList();

            foreach (var shard in allShards)
            {
                if (shard.Planets.Count <= 1)
                {
                    PlanetAllocator.AllocatePlanets(shard);
                }

                shards.Update(shard);
            }

            shards.SaveChanges();

            var allUsers = users.All().Where(x => x.PlayerObjectId == null).ToList();
            var randomShard = shards.All().OrderBy(x => Guid.NewGuid()).FirstOrDefault();

            foreach (var user in allUsers)
            {
                user.PlayerObject = PlayerAssigner.AssignPlayerObject();
                user.PlayerObject.Shard = randomShard;
                users.Update(user);
            }

            users.SaveChanges();

            var playerObjects = users.All().Select(x => x.PlayerObject).ToList();

            // check if a building was in building state, refund resources and reverse state
            foreach (var user in playerObjects)
            {
                if (user.Buildings.Barracks.IsBuilding)
                {
                    user.Buildings.Barracks.IsBuilding = false;

                    user.Resources.Energy +=
                        logicProvider.Buildings.Barracks.GetRequiredResources(user.Buildings.Barracks.Level)[0];

                    user.Resources.Crystal +=
                        logicProvider.Buildings.Barracks.GetRequiredResources(user.Buildings.Barracks.Level)[1];

                    user.Resources.Metal +=
                        logicProvider.Buildings.Barracks.GetRequiredResources(user.Buildings.Barracks.Level)[2];
                }

                if (user.Buildings.CrystalExtractor.IsBuilding)
                {
                    user.Buildings.CrystalExtractor.IsBuilding = false;

                    user.Resources.Energy +=
                        logicProvider.Buildings.CrystalExtractor.GetRequiredResources(user.Buildings.CrystalExtractor.Level)[0];

                    user.Resources.Crystal +=
                        logicProvider.Buildings.CrystalExtractor.GetRequiredResources(user.Buildings.CrystalExtractor.Level)[1];

                    user.Resources.Metal +=
                        logicProvider.Buildings.CrystalExtractor.GetRequiredResources(user.Buildings.CrystalExtractor.Level)[2];
                }

                if (user.Buildings.HeadQuarters.IsBuilding)
                {
                    user.Buildings.HeadQuarters.IsBuilding = false;

                    user.Resources.Energy +=
                        logicProvider.Buildings.Headquarters.GetRequiredResources(user.Buildings.HeadQuarters.Level)[0];

                    user.Resources.Crystal +=
                        logicProvider.Buildings.Headquarters.GetRequiredResources(user.Buildings.HeadQuarters.Level)[1];

                    user.Resources.Metal +=
                        logicProvider.Buildings.Headquarters.GetRequiredResources(user.Buildings.HeadQuarters.Level)[2];
                }

                if (user.Buildings.MetalScrapper.IsBuilding)
                {
                    user.Buildings.MetalScrapper.IsBuilding = false;

                    user.Resources.Energy +=
                        logicProvider.Buildings.MetalScrapper.GetRequiredResources(user.Buildings.MetalScrapper.Level)[0];

                    user.Resources.Crystal +=
                        logicProvider.Buildings.MetalScrapper.GetRequiredResources(user.Buildings.MetalScrapper.Level)[1];

                    user.Resources.Metal +=
                        logicProvider.Buildings.MetalScrapper.GetRequiredResources(user.Buildings.MetalScrapper.Level)[2];
                }

                if (user.Buildings.SolarCollector.IsBuilding)
                {
                    user.Buildings.SolarCollector.IsBuilding = false;

                    user.Resources.Energy +=
                        logicProvider.Buildings.SolarCollector.GetRequiredResources(user.Buildings.SolarCollector.Level)[0];

                    user.Resources.Crystal +=
                        logicProvider.Buildings.SolarCollector.GetRequiredResources(user.Buildings.SolarCollector.Level)[1];

                    user.Resources.Metal +=
                        logicProvider.Buildings.SolarCollector.GetRequiredResources(user.Buildings.SolarCollector.Level)[2];
                }

                if (user.Buildings.CrystalExtractor.IsBuilding)
                {
                    user.Buildings.CrystalExtractor.IsBuilding = false;

                    user.Resources.Energy +=
                        logicProvider.Buildings.CrystalExtractor.GetRequiredResources(user.Buildings.CrystalExtractor.Level)[0];

                    user.Resources.Crystal +=
                        logicProvider.Buildings.CrystalExtractor.GetRequiredResources(user.Buildings.CrystalExtractor.Level)[1];

                    user.Resources.Metal +=
                        logicProvider.Buildings.CrystalExtractor.GetRequiredResources(user.Buildings.CrystalExtractor.Level)[2];
                }

                if (user.Buildings.ResearchCentre.IsBuilding)
                {
                    user.Buildings.ResearchCentre.IsBuilding = false;

                    user.Resources.Energy +=
                        logicProvider.Buildings.ResearchCentre.GetRequiredResources(user.Buildings.ResearchCentre.Level)[0];

                    user.Resources.Crystal +=
                        logicProvider.Buildings.ResearchCentre.GetRequiredResources(user.Buildings.ResearchCentre.Level)[1];

                    user.Resources.Metal +=
                        logicProvider.Buildings.ResearchCentre.GetRequiredResources(user.Buildings.ResearchCentre.Level)[2];
                }
            }
        }
    }
}