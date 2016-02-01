namespace GalaxyStorm.Web.App_Start
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using Data;
    using Data.Models;
    using Data.Models.PlayerObjects;
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

            foreach (var user in allUsers)
            {
                user.PlayerObject = PlayerAssigner.AssignPlayerObject(ctx);
                users.Update(user);
            }

            users.SaveChanges();

            var playerObjects = users.All().Select(x => x.PlayerObject).ToList();

            // check if a building was in building state, refund resources and reverse state
            foreach (var user in playerObjects)
            {
                var buildings = user.Buildings;
                var logicBuildings = logicProvider.Buildings;

                if (buildings.CurrentlyBuilding != CurrentlyBuilding.None)
                {
                    switch (buildings.CurrentlyBuilding)
                    {
                        case CurrentlyBuilding.Headquarters:
                            RestoreResources(user, logicBuildings.Headquarters.GetRequiredResources(buildings.HeadQuartersLevel + 1));
                            break;
                        case CurrentlyBuilding.Barracks:
                            RestoreResources(user, logicBuildings.Barracks.GetRequiredResources(buildings.BarracksLevel + 1));
                            break;
                        case CurrentlyBuilding.ResearchCentre:
                            RestoreResources(user, logicBuildings.ResearchCentre.GetRequiredResources(buildings.ResearchCentreLevel + 1));
                            break;
                        case CurrentlyBuilding.SolarCollector:
                            RestoreResources(user, logicBuildings.SolarCollector.GetRequiredResources(buildings.SolarCollectorLevel + 1));
                            break;
                        case CurrentlyBuilding.CrystalExtractor:
                            RestoreResources(user, logicBuildings.CrystalExtractor.GetRequiredResources(buildings.CrystalExtractorLevel + 1));
                            break;
                        case CurrentlyBuilding.MetalScrapper:
                            RestoreResources(user, logicBuildings.MetalScrapper.GetRequiredResources(buildings.MetalScrapperLevel + 1));
                            break;
                        default:
                            throw new InvalidEnumArgumentException("Invalid enum value for CurrentlyBuilding. How did you get here?");
                    }

                    buildings.StartTime = null;
                    buildings.EndTime = null;
                    buildings.CurrentlyBuilding = CurrentlyBuilding.None;
                }
            }

            users.SaveChanges();
        }

        private static void RestoreResources(PlayerObject pO, int[] resources)
        {
            if (resources.Length < 3)
            {
                throw new ArgumentException();
            }

            pO.Resources.Energy += resources[0];
            pO.Resources.Crystal += resources[1];
            pO.Resources.Metal += resources[2];
        }
    }
}