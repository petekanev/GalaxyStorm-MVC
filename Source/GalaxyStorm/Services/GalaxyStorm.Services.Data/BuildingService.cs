namespace GalaxyStorm.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using GalaxyStorm.Data.Models;
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

            var toLevel = player.Buildings.HeadQuarters.Level + 1;

            if (!this.CanBuild(toLevel,
                player.Buildings.HeadQuarters.Level,
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

                player.Resources.Energy -= requiredResources[0];
                player.Resources.Crystal -= requiredResources[1];
                player.Resources.Metal -= requiredResources[2];

                var timeToBuildBeforeTech =
                    TimeSpan.FromTicks(
                        (long)(this.logic.Buildings.Headquarters.BuildTime[toLevel].Ticks * player.Shard.BuildSpeed));

                var timespan =
                    timeToBuildBeforeTech - TimeSpan.FromTicks((long)(timeToBuildBeforeTech.Ticks * this.logic.Technologies.FasterConstruction.Modifier[player.Technologies.FasterConstructionLevel]));

                player.Buildings.HeadQuarters.StartTime = DateTime.Now;
                player.Buildings.HeadQuarters.EndTime = DateTime.Now.AddTicks(timespan.Ticks);
                player.Buildings.HeadQuarters.IsBuilding = true;

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

            var toLevel = player.Buildings.Barracks.Level + 1;

            if (!this.CanBuild(toLevel,
                player.Buildings.HeadQuarters.Level,
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

                player.Resources.Energy -= requiredResources[0];
                player.Resources.Crystal -= requiredResources[1];
                player.Resources.Metal -= requiredResources[2];

                var timeToBuildBeforeTech =
                    TimeSpan.FromTicks(
                        (long)(this.logic.Buildings.Barracks.BuildTime[toLevel].Ticks * player.Shard.BuildSpeed));

                var timespan =
                    timeToBuildBeforeTech -
                    TimeSpan.FromTicks(
                        (long)
                            (timeToBuildBeforeTech.Ticks*
                             this.logic.Technologies.FasterConstruction.Modifier[
                                 player.Technologies.FasterConstructionLevel]));

                player.Buildings.Barracks.StartTime = DateTime.Now;
                player.Buildings.Barracks.EndTime = DateTime.Now.AddTicks(timespan.Ticks);
                player.Buildings.Barracks.IsBuilding = true;

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

            var toLevel = player.Buildings.ResearchCentre.Level + 1;

            if (!this.CanBuild(toLevel,
                player.Buildings.HeadQuarters.Level,
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

                player.Resources.Energy -= requiredResources[0];
                player.Resources.Crystal -= requiredResources[1];
                player.Resources.Metal -= requiredResources[2];

                var timeToBuildBeforeTech =
                    TimeSpan.FromTicks(
                        (long)(this.logic.Buildings.ResearchCentre.BuildTime[toLevel].Ticks * player.Shard.BuildSpeed));

                var timespan =
                    timeToBuildBeforeTech -
                    TimeSpan.FromTicks(
                        (long)
                            (timeToBuildBeforeTech.Ticks *
                             this.logic.Technologies.FasterConstruction.Modifier[
                                 player.Technologies.FasterConstructionLevel]));

                player.Buildings.ResearchCentre.StartTime = DateTime.Now;
                player.Buildings.ResearchCentre.EndTime = DateTime.Now.AddTicks(timespan.Ticks);
                player.Buildings.ResearchCentre.IsBuilding = true;

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

            var toLevel = player.Buildings.SolarCollector.Level + 1;

            if (!this.CanBuild(toLevel,
                player.Buildings.HeadQuarters.Level,
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

                player.Resources.Energy -= requiredResources[0];
                player.Resources.Crystal -= requiredResources[1];
                player.Resources.Metal -= requiredResources[2];

                var timeToBuildBeforeTech =
                    TimeSpan.FromTicks(
                        (long)(this.logic.Buildings.SolarCollector.BuildTime[toLevel].Ticks * player.Shard.BuildSpeed));

                var timespan =
                    timeToBuildBeforeTech -
                    TimeSpan.FromTicks(
                        (long)
                            (timeToBuildBeforeTech.Ticks *
                             this.logic.Technologies.FasterConstruction.Modifier[
                                 player.Technologies.FasterConstructionLevel]));

                player.Buildings.SolarCollector.StartTime = DateTime.Now;
                player.Buildings.SolarCollector.EndTime = DateTime.Now.AddTicks(timespan.Ticks);
                player.Buildings.SolarCollector.IsBuilding = true;

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

            var toLevel = player.Buildings.CrystalExtractor.Level + 1;

            if (!this.CanBuild(toLevel,
                player.Buildings.HeadQuarters.Level,
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

                player.Resources.Energy -= requiredResources[0];
                player.Resources.Crystal -= requiredResources[1];
                player.Resources.Metal -= requiredResources[2];

                var timeToBuildBeforeTech =
                    TimeSpan.FromTicks(
                        (long)(this.logic.Buildings.CrystalExtractor.BuildTime[toLevel].Ticks * player.Shard.BuildSpeed));

                var timespan =
                    timeToBuildBeforeTech -
                    TimeSpan.FromTicks(
                        (long)
                            (timeToBuildBeforeTech.Ticks *
                             this.logic.Technologies.FasterConstruction.Modifier[
                                 player.Technologies.FasterConstructionLevel]));

                player.Buildings.CrystalExtractor.StartTime = DateTime.Now;
                player.Buildings.CrystalExtractor.EndTime = DateTime.Now.AddTicks(timespan.Ticks);
                player.Buildings.CrystalExtractor.IsBuilding = true;

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

            var toLevel = player.Buildings.MetalScrapper.Level + 1;

            if (!this.CanBuild(toLevel,
                player.Buildings.HeadQuarters.Level,
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

                player.Resources.Energy -= requiredResources[0];
                player.Resources.Crystal -= requiredResources[1];
                player.Resources.Metal -= requiredResources[2];

                var timeToBuildBeforeTech =
                    TimeSpan.FromTicks(
                        (long)(this.logic.Buildings.MetalScrapper.BuildTime[toLevel].Ticks * player.Shard.BuildSpeed));

                var timespan =
                    timeToBuildBeforeTech -
                    TimeSpan.FromTicks(
                        (long)
                            (timeToBuildBeforeTech.Ticks *
                             this.logic.Technologies.FasterConstruction.Modifier[
                                 player.Technologies.FasterConstructionLevel]));

                player.Buildings.MetalScrapper.StartTime = DateTime.Now;
                player.Buildings.MetalScrapper.EndTime = DateTime.Now.AddTicks(timespan.Ticks);
                player.Buildings.MetalScrapper.IsBuilding = true;

                this.users.Update(user);
                this.users.SaveChanges();

                return timespan;
            }
        }

        public void CompleteBuildHeadQuarters(string userId)
        {
            var user = this.users
                   .All()
                   .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return;
            }

            var player = user.PlayerObject;
            player.Buildings.HeadQuarters.Level += 1;
            player.Buildings.HeadQuarters.IsBuilding = false;
            player.Buildings.HeadQuarters.StartTime = null;
            player.Buildings.HeadQuarters.EndTime = null;
        }

        public void CompleteBuildBarracks(string userId)
        {
            var user = this.users
                   .All()
                   .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return;
            }

            var player = user.PlayerObject;
            player.Buildings.Barracks.Level += 1;
            player.Buildings.Barracks.IsBuilding = false;
            player.Buildings.Barracks.StartTime = null;
            player.Buildings.Barracks.EndTime = null;
        }

        public void CompleteBuildResearchCentre(string userId)
        {
            var user = this.users
                   .All()
                   .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return;
            }

            var player = user.PlayerObject;
            player.Buildings.ResearchCentre.Level += 1;
            player.Buildings.ResearchCentre.IsBuilding = false;
            player.Buildings.ResearchCentre.StartTime = null;
            player.Buildings.ResearchCentre.EndTime = null;
        }

        public void CompleteBuildSolarCollector(string userId)
        {
            var user = this.users
                      .All()
                      .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return;
            }

            var player = user.PlayerObject;
            player.Buildings.SolarCollector.Level += 1;
            player.Buildings.SolarCollector.IsBuilding = false;
            player.Buildings.SolarCollector.StartTime = null;
            player.Buildings.SolarCollector.EndTime = null;
        }

        public void CompleteBuildCrystalExtractor(string userId)
        {
            var user = this.users
                   .All()
                   .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return;
            }

            var player = user.PlayerObject;
            player.Buildings.CrystalExtractor.Level += 1;
            player.Buildings.CrystalExtractor.IsBuilding = false;
            player.Buildings.CrystalExtractor.StartTime = null;
            player.Buildings.CrystalExtractor.EndTime = null;
        }

        public void CompleteBuildMetalScrapper(string userId)
        {
            var user = this.users
                   .All()
                   .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return;
            }

            var player = user.PlayerObject;
            player.Buildings.MetalScrapper.Level += 1;
            player.Buildings.MetalScrapper.IsBuilding = false;
            player.Buildings.MetalScrapper.StartTime = null;
            player.Buildings.MetalScrapper.EndTime = null;
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

    }
}
