namespace GalaxyStorm.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using GalaxyStorm.Data.Models;
    using GalaxyStorm.Data.Repositories;
    using Logic.Core;

    public class BuildingService : IBuildingsService
    {
        private IRepository<ApplicationUser> users;

        private ILogicProvider logic;

        public BuildingService(IRepository<ApplicationUser> users, ILogicProvider logic)
        {
            this.users = users;
            this.logic = logic;
        }

        /// <summary>
        /// Check if:
        /// building can be updated
        /// user has all the required resources
        /// building meets prerequisites and is of level lower or equal to HQs
        /// Then:
        /// take resources
        /// calculate timespan based on shard variables and technologies
        /// set start and end time
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Timespan to completion or null if something goes wrong</returns>
        public TimeSpan? ScheduleBuildHeadQuarters(string userId)
        {
            var player = this.users
                .All()
                .FirstOrDefault(u => u.Id == userId)
                .PlayerObject;

            var toLevel = player.Buildings.HeadQuarters.Level + 1;

            if (toLevel > logic.Buildings.Headquarters.MaxLevel)
            {
                return null;
            }

            if (toLevel < logic.Buildings.Headquarters.Prerequisite)
            {
                return null;
            }

            var requiredResources = logic.Buildings.Headquarters.GetRequiredResources(toLevel);

            if (requiredResources[0] > player.Resources.Energy 
                || requiredResources[1] > player.Resources.Crystal
                || requiredResources[2] > player.Resources.Metal)
            {
                return null;
            }

            player.Resources.Energy -= requiredResources[0];
            player.Resources.Crystal -= requiredResources[1];
            player.Resources.Metal -= requiredResources[2];

            var timeToBuildBeforeTech =
                TimeSpan.FromTicks(
                    (long) (logic.Buildings.Headquarters.BuildTime[toLevel].Ticks*player.Shard.BuildSpeed));

            var timespan = timeToBuildBeforeTech;

            return timespan;
        }

        public TimeSpan? ScheduleBuildBarracks(string userId)
        {
            throw new NotImplementedException();
        }

        public TimeSpan? ScheduleResearchCentre(string userId)
        {
            throw new NotImplementedException();
        }

        public TimeSpan? ScheduleSolarCollector(string userId)
        {
            throw new NotImplementedException();
        }

        public TimeSpan? ScheduleCrystalExtractor(string userId)
        {
            throw new NotImplementedException();
        }

        public TimeSpan? ScheduleMetalScrapper(string userId)
        {
            throw new NotImplementedException();
        }

        public void CompleteBuildHeadQuarters(string userId)
        {
            throw new NotImplementedException();
        }

        public void CompleteBuildBarracks(string userId)
        {
            throw new NotImplementedException();
        }

        public void CompleteBuildResearchCentre(string userId)
        {
            throw new NotImplementedException();
        }

        public void CompleteBuildSolarCollector(string userId)
        {
            throw new NotImplementedException();
        }

        public void CompleteBuildCrystalExtractor(string userId)
        {
            throw new NotImplementedException();
        }

        public void CompleteBuildMetalScrapper(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
