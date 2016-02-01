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
                .Include(x => x.PlayerObject)
                .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return null;
            }

            var player = user.PlayerObject;

            var toLevel = player.Buildings.HeadQuartersLevel + 1;

            if (!this.CanBuild(player, toLevel, this.logic.Buildings.Headquarters))
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

            if (!this.CanBuild(player, toLevel, this.logic.Buildings.Barracks))
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

            if (!this.CanBuild(player, toLevel, this.logic.Buildings.ResearchCentre))
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

            if (!this.CanBuild(player, toLevel, this.logic.Buildings.SolarCollector))
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

            if (!this.CanBuild(player, toLevel, this.logic.Buildings.CrystalExtractor))
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

            if (!this.CanBuild(player, toLevel, this.logic.Buildings.MetalScrapper))
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
                   .Include(x => x.PlayerObject)
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
                    player.Points.PointsPlanet += player.Buildings.HeadQuartersLevel * 100;
                    break;
                case CurrentlyBuilding.Barracks:
                    player.Buildings.BarracksLevel += 1;
                    player.Points.PointsPlanet += player.Buildings.BarracksLevel * 50;
                    break;
                case CurrentlyBuilding.ResearchCentre:
                    player.Buildings.ResearchCentreLevel += 1;
                    player.Points.PointsPlanet += player.Buildings.ResearchCentreLevel * 75;
                    break;
                case CurrentlyBuilding.SolarCollector:
                    player.Buildings.SolarCollectorLevel += 1;
                    player.Points.PointsPlanet += player.Buildings.SolarCollectorLevel * 10;
                    break;
                case CurrentlyBuilding.CrystalExtractor:
                    player.Buildings.CrystalExtractorLevel += 1;
                    player.Points.PointsPlanet += player.Buildings.CrystalExtractorLevel * 10;
                    break;
                case CurrentlyBuilding.MetalScrapper:
                    player.Buildings.MetalScrapperLevel += 1;
                    player.Points.PointsPlanet += player.Buildings.MetalScrapperLevel * 10;
                    break;
                default:
                    break;
            }

            player.Buildings.CurrentlyBuilding = CurrentlyBuilding.None;
            player.Buildings.StartTime = null;
            player.Buildings.EndTime = null;

            this.users.Update(user);
            this.users.SaveChanges();
        }

        private bool CanBuild(PlayerObject pO, int toLevel, IBuilding buildingLogic)
        {
            if (pO.Buildings.CurrentlyBuilding != CurrentlyBuilding.None)
            {
                return false;
            }

            if (toLevel > buildingLogic.MaxLevel)
            {
                return false;
            }

            if (toLevel < buildingLogic.Prerequisite)
            {
                return false;
            }

            if (toLevel > pO.Buildings.HeadQuartersLevel && buildingLogic.Name != "Headquarters")
            {
                return false;
            }

            var requiredResources = buildingLogic.GetRequiredResources(toLevel);

            return pO.Resources.Energy > requiredResources[0]
                && pO.Resources.Crystal > requiredResources[1]
                && pO.Resources.Metal > requiredResources[2];
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
