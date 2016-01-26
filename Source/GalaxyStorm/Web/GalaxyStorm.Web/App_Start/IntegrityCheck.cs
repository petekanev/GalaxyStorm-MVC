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

                user.Buildings.IsUpdatingCrystalExtractor = false;
                user.Buildings.IsUpdatingHeadQuarters = false;
                user.Buildings.IsUpdatingMetalScrapper = false;
                user.Buildings.IsUpdatingSolarCollector = false;
                user.Buildings.IsUpdatingResearchCentre = false;
            }
        }
    }
}