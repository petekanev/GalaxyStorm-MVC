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
                        BuildingsBundle.Barracks.GetRequiredResources(user.Buildings.Barracks.Level)[0];

                    user.Resources.Crystal +=
                        BuildingsBundle.Barracks.GetRequiredResources(user.Buildings.Barracks.Level)[1];

                    user.Resources.Metal +=
                        BuildingsBundle.Barracks.GetRequiredResources(user.Buildings.Barracks.Level)[2];
                }

                if (user.Buildings.CrystalExtractor.IsBuilding)
                {
                    user.Buildings.CrystalExtractor.IsBuilding = false;

                    user.Resources.Energy +=
                       BuildingsBundle.CrystalExtractor.GetRequiredResources(user.Buildings.CrystalExtractor.Level)[0];

                    user.Resources.Crystal +=
                        BuildingsBundle.CrystalExtractor.GetRequiredResources(user.Buildings.CrystalExtractor.Level)[1];

                    user.Resources.Metal +=
                        BuildingsBundle.CrystalExtractor.GetRequiredResources(user.Buildings.CrystalExtractor.Level)[2];
                }

                if (user.Buildings.HeadQuarters.IsBuilding)
                {
                    user.Buildings.HeadQuarters.IsBuilding = false;

                    user.Resources.Energy +=
                       BuildingsBundle.Headquarters.GetRequiredResources(user.Buildings.HeadQuarters.Level)[0];

                    user.Resources.Crystal +=
                        BuildingsBundle.Headquarters.GetRequiredResources(user.Buildings.HeadQuarters.Level)[1];

                    user.Resources.Metal +=
                        BuildingsBundle.Headquarters.GetRequiredResources(user.Buildings.HeadQuarters.Level)[2];
                }

                if (user.Buildings.MetalScrapper.IsBuilding)
                {
                    user.Buildings.MetalScrapper.IsBuilding = false;

                    user.Resources.Energy +=
                       BuildingsBundle.MetalScrapper.GetRequiredResources(user.Buildings.MetalScrapper.Level)[0];

                    user.Resources.Crystal +=
                        BuildingsBundle.MetalScrapper.GetRequiredResources(user.Buildings.MetalScrapper.Level)[1];

                    user.Resources.Metal +=
                        BuildingsBundle.MetalScrapper.GetRequiredResources(user.Buildings.MetalScrapper.Level)[2];
                }

                if (user.Buildings.SolarCollector.IsBuilding)
                {
                    user.Buildings.SolarCollector.IsBuilding = false;

                    user.Resources.Energy +=
                       BuildingsBundle.SolarCollector.GetRequiredResources(user.Buildings.SolarCollector.Level)[0];

                    user.Resources.Crystal +=
                        BuildingsBundle.SolarCollector.GetRequiredResources(user.Buildings.SolarCollector.Level)[1];

                    user.Resources.Metal +=
                        BuildingsBundle.SolarCollector.GetRequiredResources(user.Buildings.SolarCollector.Level)[2];
                }

                if (user.Buildings.CrystalExtractor.IsBuilding)
                {
                    user.Buildings.CrystalExtractor.IsBuilding = false;

                    user.Resources.Energy +=
                       BuildingsBundle.CrystalExtractor.GetRequiredResources(user.Buildings.CrystalExtractor.Level)[0];

                    user.Resources.Crystal +=
                        BuildingsBundle.CrystalExtractor.GetRequiredResources(user.Buildings.CrystalExtractor.Level)[1];

                    user.Resources.Metal +=
                        BuildingsBundle.CrystalExtractor.GetRequiredResources(user.Buildings.CrystalExtractor.Level)[2];
                }

                if (user.Buildings.ResearchCentre.IsBuilding)
                {
                    user.Buildings.ResearchCentre.IsBuilding = false;

                    user.Resources.Energy +=
                       BuildingsBundle.ResearchCentre.GetRequiredResources(user.Buildings.ResearchCentre.Level)[0];

                    user.Resources.Crystal +=
                        BuildingsBundle.ResearchCentre.GetRequiredResources(user.Buildings.ResearchCentre.Level)[1];

                    user.Resources.Metal +=
                        BuildingsBundle.ResearchCentre.GetRequiredResources(user.Buildings.ResearchCentre.Level)[2];
                }
            }
        }
    }
}