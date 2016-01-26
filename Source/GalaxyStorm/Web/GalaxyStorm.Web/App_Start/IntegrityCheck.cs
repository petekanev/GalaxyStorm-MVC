namespace GalaxyStorm.Web.App_Start
{
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

            var allUsers = users.All().Select(x => x.PlayerObject).ToList();

            // check if a building was in building state, refund resources and reverse state
            foreach (var user in allUsers)
            {
                if (user.Buildings.IsUpdatingBarracks)
                {
                    user.Buildings.IsUpdatingBarracks = false;

                    user.Resources.Energy +=
                        BuildingsBundle.Barracks.GetRequiredResources(user.Buildings.BarracksLevel)[0];

                    user.Resources.Crystal +=
                        BuildingsBundle.Barracks.GetRequiredResources(user.Buildings.BarracksLevel)[1];

                    user.Resources.Metal +=
                        BuildingsBundle.Barracks.GetRequiredResources(user.Buildings.BarracksLevel)[2];
                }

                if (user.Buildings.IsUpdatingCrystalExtractor)
                {
                    user.Buildings.IsUpdatingCrystalExtractor = false;

                    user.Resources.Energy +=
                       BuildingsBundle.CrystalExtractor.GetRequiredResources(user.Buildings.CrystalExtractorLevel)[0];

                    user.Resources.Crystal +=
                        BuildingsBundle.CrystalExtractor.GetRequiredResources(user.Buildings.CrystalExtractorLevel)[1];

                    user.Resources.Metal +=
                        BuildingsBundle.CrystalExtractor.GetRequiredResources(user.Buildings.CrystalExtractorLevel)[2];
                }

                if (user.Buildings.IsUpdatingHeadQuarters)
                {
                    user.Buildings.IsUpdatingHeadQuarters = false;

                    user.Resources.Energy +=
                       BuildingsBundle.Headquarters.GetRequiredResources(user.Buildings.HeadQuartersLevel)[0];

                    user.Resources.Crystal +=
                        BuildingsBundle.Headquarters.GetRequiredResources(user.Buildings.HeadQuartersLevel)[1];

                    user.Resources.Metal +=
                        BuildingsBundle.Headquarters.GetRequiredResources(user.Buildings.HeadQuartersLevel)[2];
                }

                if (user.Buildings.IsUpdatingMetalScrapper)
                {
                    user.Buildings.IsUpdatingMetalScrapper = false;

                    user.Resources.Energy +=
                       BuildingsBundle.MetalScrapper.GetRequiredResources(user.Buildings.MetalScrapperLevel)[0];

                    user.Resources.Crystal +=
                        BuildingsBundle.MetalScrapper.GetRequiredResources(user.Buildings.MetalScrapperLevel)[1];

                    user.Resources.Metal +=
                        BuildingsBundle.MetalScrapper.GetRequiredResources(user.Buildings.MetalScrapperLevel)[2];
                }

                if (user.Buildings.IsUpdatingSolarCollector)
                {
                    user.Buildings.IsUpdatingSolarCollector = false;

                    user.Resources.Energy +=
                       BuildingsBundle.SolarCollector.GetRequiredResources(user.Buildings.SolarCollectorLevel)[0];

                    user.Resources.Crystal +=
                        BuildingsBundle.SolarCollector.GetRequiredResources(user.Buildings.SolarCollectorLevel)[1];

                    user.Resources.Metal +=
                        BuildingsBundle.SolarCollector.GetRequiredResources(user.Buildings.SolarCollectorLevel)[2];
                }

                if (user.Buildings.IsUpdatingCrystalExtractor)
                {
                    user.Buildings.IsUpdatingCrystalExtractor = false;

                    user.Resources.Energy +=
                       BuildingsBundle.CrystalExtractor.GetRequiredResources(user.Buildings.CrystalExtractorLevel)[0];

                    user.Resources.Crystal +=
                        BuildingsBundle.CrystalExtractor.GetRequiredResources(user.Buildings.CrystalExtractorLevel)[1];

                    user.Resources.Metal +=
                        BuildingsBundle.CrystalExtractor.GetRequiredResources(user.Buildings.CrystalExtractorLevel)[2];
                }

                if (user.Buildings.IsUpdatingResearchCentre)
                {
                    user.Buildings.IsUpdatingResearchCentre = false;

                    user.Resources.Energy +=
                       BuildingsBundle.ResearchCentre.GetRequiredResources(user.Buildings.ResearchCentreLevel)[0];

                    user.Resources.Crystal +=
                        BuildingsBundle.ResearchCentre.GetRequiredResources(user.Buildings.ResearchCentreLevel)[1];

                    user.Resources.Metal +=
                        BuildingsBundle.ResearchCentre.GetRequiredResources(user.Buildings.ResearchCentreLevel)[2];
                }
            }
        }
    }
}