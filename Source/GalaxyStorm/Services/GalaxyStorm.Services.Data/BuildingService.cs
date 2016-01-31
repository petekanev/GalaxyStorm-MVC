namespace GalaxyStorm.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using GalaxyStorm.Data.Models;
    using GalaxyStorm.Data.Models.PlayerObjects;
    using GalaxyStorm.Data.Repositories;
    using Logic.Core;
    using Logic.Core.Buildings;

    public class BuildingService : IBuildingsService
    {
        private readonly IRepository<ApplicationUser> users;

        private readonly ILogicProvider logic;

        public BuildingService(IRepository<ApplicationUser> users, ILogicProvider logic)
        {
            this.users = users;
            this.logic = logic;
        }

        /// <summary>
        /// Perform necessary checks and then take resources from player, set end date
        /// and return timespan for the background worker to trigger an even when time has elapsed
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Timespan to completion or null if something goes wrong</returns>
        public TimeSpan? ScheduleBuildHeadQuarters(string userId)
        {
            var user = this.users
                .All()
                .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return null;
            }

            var player = user.PlayerObject;

            var toLevel = player.Buildings.HeadQuartersLevel + 1;

            if (!this.CanBuild(toLevel,
                player.Buildings.HeadQuartersLevel,
                this.logic.Buildings.Headquarters,
                player.Resources.Energy,
                player.Resources.Crystal,
                player.Resources.Metal))
            {
                return null;
            }
            else
            {
                var requiredResources = this.logic.Buildings.Headquarters.GetRequiredResources(toLevel);

                this.SubstractResources(player, requiredResources);

                var timeToBuildBeforeTech =
                    TimeSpan.FromTicks(
                        (long)(this.logic.Buildings.Headquarters.BuildTime[toLevel].Ticks * player.Planet.Shard.BuildSpeed));

                var timespan =
                    timeToBuildBeforeTech - TimeSpan.FromTicks((long)(timeToBuildBeforeTech.Ticks * this.logic.Technologies.FasterConstruction.Modifier[player.Technologies.FasterConstructionLevel]));

                player.Buildings.StartTime = DateTime.Now;
                player.Buildings.EndTime = DateTime.Now.AddTicks(timespan.Ticks);
                player.Buildings.CurrentlyBuilding = CurrentlyBuilding.Headquarters;

                this.users.Update(user);
                this.users.SaveChanges();

                return timespan;
            }
        }

        public TimeSpan? ScheduleBuildBarracks(string userId)
        {
            var user = this.users
                .All()
                .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return null;
            }

            var player = user.PlayerObject;

            var toLevel = player.Buildings.BarracksLevel + 1;

            if (!this.CanBuild(toLevel,
                player.Buildings.HeadQuartersLevel,
                this.logic.Buildings.Barracks,
                player.Resources.Energy,
                player.Resources.Crystal,
                player.Resources.Metal))
            {
                return null;
            }
            else
            {
                var requiredResources = this.logic.Buildings.Barracks.GetRequiredResources(toLevel);

                this.SubstractResources(player, requiredResources);

                var timeToBuildBeforeTech =
                    TimeSpan.FromTicks(
                        (long)(this.logic.Buildings.Barracks.BuildTime[toLevel].Ticks * player.Planet.Shard.BuildSpeed));

                var timespan =
                    timeToBuildBeforeTech -
                    TimeSpan.FromTicks(
                        (long)
                            (timeToBuildBeforeTech.Ticks *
                             this.logic.Technologies.FasterConstruction.Modifier[
                                 player.Technologies.FasterConstructionLevel]));

                player.Buildings.StartTime = DateTime.Now;
                player.Buildings.EndTime = DateTime.Now.AddTicks(timespan.Ticks);
                player.Buildings.CurrentlyBuilding = CurrentlyBuilding.Barracks;

                this.users.Update(user);
                this.users.SaveChanges();

                return timespan;
            }
        }

        public TimeSpan? ScheduleResearchCentre(string userId)
        {
            var user = this.users
                .All()
                .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return null;
            }

            var player = user.PlayerObject;

            var toLevel = player.Buildings.ResearchCentreLevel + 1;

            if (!this.CanBuild(toLevel,
                player.Buildings.HeadQuartersLevel,
                this.logic.Buildings.ResearchCentre,
                player.Resources.Energy,
                player.Resources.Crystal,
                player.Resources.Metal))
            {
                return null;
            }
            else
            {
                var requiredResources = this.logic.Buildings.ResearchCentre.GetRequiredResources(toLevel);

                this.SubstractResources(player, requiredResources);

                var timeToBuildBeforeTech =
                    TimeSpan.FromTicks(
                        (long)(this.logic.Buildings.ResearchCentre.BuildTime[toLevel].Ticks * player.Planet.Shard.BuildSpeed));

                var timespan =
                    timeToBuildBeforeTech -
                    TimeSpan.FromTicks(
                        (long)
                            (timeToBuildBeforeTech.Ticks *
                             this.logic.Technologies.FasterConstruction.Modifier[
                                 player.Technologies.FasterConstructionLevel]));

                player.Buildings.StartTime = DateTime.Now;
                player.Buildings.EndTime = DateTime.Now.AddTicks(timespan.Ticks);
                player.Buildings.CurrentlyBuilding = CurrentlyBuilding.ResearchCentre;

                this.users.Update(user);
                this.users.SaveChanges();

                return timespan;
            }
        }

        public TimeSpan? ScheduleSolarCollector(string userId)
        {
            var user = this.users
                .All()
                .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return null;
            }

            var player = user.PlayerObject;

            var toLevel = player.Buildings.SolarCollectorLevel + 1;

            if (!this.CanBuild(toLevel,
                player.Buildings.HeadQuartersLevel,
                this.logic.Buildings.SolarCollector,
                player.Resources.Energy,
                player.Resources.Crystal,
                player.Resources.Metal))
            {
                return null;
            }
            else
            {
                var requiredResources = this.logic.Buildings.SolarCollector.GetRequiredResources(toLevel);

                this.SubstractResources(player, requiredResources);

                var timeToBuildBeforeTech =
                    TimeSpan.FromTicks(
                        (long)(this.logic.Buildings.SolarCollector.BuildTime[toLevel].Ticks * player.Planet.Shard.BuildSpeed));

                var timespan =
                    timeToBuildBeforeTech -
                    TimeSpan.FromTicks(
                        (long)
                            (timeToBuildBeforeTech.Ticks *
                             this.logic.Technologies.FasterConstruction.Modifier[
                                 player.Technologies.FasterConstructionLevel]));

                player.Buildings.StartTime = DateTime.Now;
                player.Buildings.EndTime = DateTime.Now.AddTicks(timespan.Ticks);
                player.Buildings.CurrentlyBuilding = CurrentlyBuilding.SolarCollector;

                this.users.Update(user);
                this.users.SaveChanges();

                return timespan;
            }
        }

        public TimeSpan? ScheduleCrystalExtractor(string userId)
        {
            var user = this.users
                .All()
                .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return null;
            }

            var player = user.PlayerObject;

            var toLevel = player.Buildings.CrystalExtractorLevel + 1;

            if (!this.CanBuild(toLevel,
                player.Buildings.HeadQuartersLevel,
                this.logic.Buildings.CrystalExtractor,
                player.Resources.Energy,
                player.Resources.Crystal,
                player.Resources.Metal))
            {
                return null;
            }
            else
            {
                var requiredResources = this.logic.Buildings.CrystalExtractor.GetRequiredResources(toLevel);

                this.SubstractResources(player, requiredResources);

                var timeToBuildBeforeTech =
                    TimeSpan.FromTicks(
                        (long)(this.logic.Buildings.CrystalExtractor.BuildTime[toLevel].Ticks * player.Planet.Shard.BuildSpeed));

                var timespan =
                    timeToBuildBeforeTech -
                    TimeSpan.FromTicks(
                        (long)
                            (timeToBuildBeforeTech.Ticks *
                             this.logic.Technologies.FasterConstruction.Modifier[
                                 player.Technologies.FasterConstructionLevel]));

                player.Buildings.StartTime = DateTime.Now;
                player.Buildings.EndTime = DateTime.Now.AddTicks(timespan.Ticks);
                player.Buildings.CurrentlyBuilding = CurrentlyBuilding.CrystalExtractor;

                this.users.Update(user);
                this.users.SaveChanges();

                return timespan;
            }
        }

        public TimeSpan? ScheduleMetalScrapper(string userId)
        {
            var user = this.users
                .All()
                .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return null;
            }

            var player = user.PlayerObject;

            var toLevel = player.Buildings.MetalScrapperLevel + 1;

            if (!this.CanBuild(toLevel,
                player.Buildings.HeadQuartersLevel,
                this.logic.Buildings.MetalScrapper,
                player.Resources.Energy,
                player.Resources.Crystal,
                player.Resources.Metal))
            {
                return null;
            }
            else
            {
                var requiredResources = this.logic.Buildings.MetalScrapper.GetRequiredResources(toLevel);

                this.SubstractResources(player, requiredResources);

                var timeToBuildBeforeTech =
                    TimeSpan.FromTicks(
                        (long)(this.logic.Buildings.MetalScrapper.BuildTime[toLevel].Ticks * player.Planet.Shard.BuildSpeed));

                var timespan =
                    timeToBuildBeforeTech -
                    TimeSpan.FromTicks(
                        (long)
                            (timeToBuildBeforeTech.Ticks *
                             this.logic.Technologies.FasterConstruction.Modifier[
                                 player.Technologies.FasterConstructionLevel]));

                player.Buildings.StartTime = DateTime.Now;
                player.Buildings.EndTime = DateTime.Now.AddTicks(timespan.Ticks);
                player.Buildings.CurrentlyBuilding = CurrentlyBuilding.MetalScrapper;

                this.users.Update(user);
                this.users.SaveChanges();

                return timespan;
            }
        }

        public void CompleteBuilding(string userId)
        {
            var user = this.users
                   .All()
                   .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return;
            }

            var player = user.PlayerObject;

            switch (player.Buildings.CurrentlyBuilding)
            {
                case CurrentlyBuilding.Headquarters:
                    player.Buildings.HeadQuartersLevel += 1;
                    break;
                case CurrentlyBuilding.Barracks:
                    player.Buildings.BarracksLevel += 1;
                    break;
                case CurrentlyBuilding.ResearchCentre:
                    player.Buildings.ResearchCentreLevel += 1;
                    break;
                case CurrentlyBuilding.SolarCollector:
                    player.Buildings.SolarCollectorLevel += 1;
                    break;
                case CurrentlyBuilding.CrystalExtractor:
                    player.Buildings.CrystalExtractorLevel += 1;
                    break;
                case CurrentlyBuilding.MetalScrapper:
                    player.Buildings.MetalScrapperLevel += 1;
                    break;
                default:
                    break;
            }

            player.Buildings.CurrentlyBuilding = CurrentlyBuilding.None;
            player.Buildings.StartTime = null;
            player.Buildings.EndTime = null;
        }

        private bool CanBuild(int toLevel, int hqLevel, IBuilding buildingLogic, long energy, long crystal, long metal)
        {
            if (toLevel > buildingLogic.MaxLevel)
            {
                return false;
            }

            if (toLevel < buildingLogic.Prerequisite)
            {
                return false;
            }

            if (toLevel > hqLevel && buildingLogic.Name != "Headquarters")
            {
                return false;
            }

            var requiredResources = buildingLogic.GetRequiredResources(toLevel);

            return energy > requiredResources[0]
                && crystal > requiredResources[1]
                && metal > requiredResources[2];
        }

        private void SubstractResources(PlayerObject pO, int[] resources)
        {
            if (resources.Length < 3)
            {
                throw new ArgumentException();
            }

            pO.Resources.Energy -= resources[0];
            pO.Resources.Crystal -= resources[1];
            pO.Resources.Metal -= resources[2];
        }

    }
}
