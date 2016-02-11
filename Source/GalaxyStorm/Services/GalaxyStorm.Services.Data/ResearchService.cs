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
    using Logic.Core.Technologies;

    public class ResearchService : IResearchService
    {
        private readonly IRepository<ApplicationUser> users;

        private readonly ILogicProvider logic;

        public ResearchService(IRepository<ApplicationUser> users, ILogicProvider logic)
        {
            this.users = users;
            this.logic = logic;
        }

        public TimeSpan? ScheduleResearchArmoredFleet(string userId)
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

            var toLevel = player.Technologies.ArmoredFleetLevel + 1;

            if (!this.CanResearch(player, toLevel, this.logic.Technologies.ArmoredFleet))
            {
                return null;
            }
            else
            {
                var requiredResources = this.logic.Technologies.ArmoredFleet.GetRequiredResources(toLevel);

                this.SubstractResources(player, requiredResources);

                var timespanToResearch =
                    TimeSpan.FromTicks(
                        (long)
                            (this.logic.Technologies.ArmoredFleet.ResearchTime[toLevel].Ticks*
                             player.Planet.Shard.BuildSpeed));

                player.Technologies.StartTime = DateTime.Now;
                player.Technologies.EndTime = DateTime.Now.AddTicks(timespanToResearch.Ticks);
                player.Technologies.CurrentlyResearching = CurrentlyResearching.ArmoredFleet;

                this.users.Update(user);
                this.users.SaveChanges();

                return timespanToResearch;
            }
        }

        public TimeSpan? ScheduleResearchCheaperFleet(string userId)
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

            var toLevel = player.Technologies.CheaperFleetLevel + 1;

            if (!this.CanResearch(player, toLevel, this.logic.Technologies.CheaperFleet))
            {
                return null;
            }
            else
            {
                var requiredResources = this.logic.Technologies.CheaperFleet.GetRequiredResources(toLevel);

                this.SubstractResources(player, requiredResources);

                var timespanToResearch =
                    TimeSpan.FromTicks(
                        (long)
                            (this.logic.Technologies.CheaperFleet.ResearchTime[toLevel].Ticks *
                             player.Planet.Shard.BuildSpeed));

                player.Technologies.StartTime = DateTime.Now;
                player.Technologies.EndTime = DateTime.Now.AddTicks(timespanToResearch.Ticks);
                player.Technologies.CurrentlyResearching = CurrentlyResearching.CheaperFleet;

                this.users.Update(user);
                this.users.SaveChanges();

                return timespanToResearch;
            }
        }

        public TimeSpan? ScheduleResearchLargerFleet(string userId)
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

            var toLevel = player.Technologies.LargerFleetLevel + 1;

            if (!this.CanResearch(player, toLevel, this.logic.Technologies.LargerFleet))
            {
                return null;
            }
            else
            {
                var requiredResources = this.logic.Technologies.LargerFleet.GetRequiredResources(toLevel);

                this.SubstractResources(player, requiredResources);

                var timespanToResearch =
                    TimeSpan.FromTicks(
                        (long)
                            (this.logic.Technologies.LargerFleet.ResearchTime[toLevel].Ticks *
                             player.Planet.Shard.BuildSpeed));

                player.Technologies.StartTime = DateTime.Now;
                player.Technologies.EndTime = DateTime.Now.AddTicks(timespanToResearch.Ticks);
                player.Technologies.CurrentlyResearching = CurrentlyResearching.LargerFleet;

                this.users.Update(user);
                this.users.SaveChanges();

                return timespanToResearch;
            }
        }

        public TimeSpan? ScheduleResearchMoreResources(string userId)
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

            var toLevel = player.Technologies.MoreResourcesLevel + 1;

            if (!this.CanResearch(player, toLevel, this.logic.Technologies.MoreResources))
            {
                return null;
            }
            else
            {
                var requiredResources = this.logic.Technologies.MoreResources.GetRequiredResources(toLevel);

                this.SubstractResources(player, requiredResources);

                var timespanToResearch =
                    TimeSpan.FromTicks(
                        (long)
                            (this.logic.Technologies.MoreResources.ResearchTime[toLevel].Ticks *
                             player.Planet.Shard.BuildSpeed));

                player.Technologies.StartTime = DateTime.Now;
                player.Technologies.EndTime = DateTime.Now.AddTicks(timespanToResearch.Ticks);
                player.Technologies.CurrentlyResearching = CurrentlyResearching.MoreResources;

                this.users.Update(user);
                this.users.SaveChanges();

                return timespanToResearch;
            }
        }

        public TimeSpan? ScheduleResearchFasterConstruction(string userId)
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

            var toLevel = player.Technologies.FasterConstructionLevel + 1;

            if (!this.CanResearch(player, toLevel, this.logic.Technologies.FasterConstruction))
            {
                return null;
            }
            else
            {
                var requiredResources = this.logic.Technologies.FasterConstruction.GetRequiredResources(toLevel);

                this.SubstractResources(player, requiredResources);

                var timespanToResearch =
                    TimeSpan.FromTicks(
                        (long)
                            (this.logic.Technologies.FasterConstruction.ResearchTime[toLevel].Ticks *
                             player.Planet.Shard.BuildSpeed));

                player.Technologies.StartTime = DateTime.Now;
                player.Technologies.EndTime = DateTime.Now.AddTicks(timespanToResearch.Ticks);
                player.Technologies.CurrentlyResearching = CurrentlyResearching.FasterConstruction;

                this.users.Update(user);
                this.users.SaveChanges();

                return timespanToResearch;
            }
        }

        public void CompleteResearching(string userId)
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

            switch (player.Technologies.CurrentlyResearching)
            {
                case CurrentlyResearching.ArmoredFleet:
                    player.Technologies.ArmoredFleetLevel += 1;
                    break;
                case CurrentlyResearching.CheaperFleet:
                    player.Technologies.CheaperFleetLevel += 1;
                    break;
                case CurrentlyResearching.LargerFleet:
                    player.Technologies.LargerFleetLevel += 1;
                    break;
                case CurrentlyResearching.FasterConstruction:
                    player.Technologies.FasterConstructionLevel += 1;
                    break;
                case CurrentlyResearching.MoreResources:
                    player.Technologies.MoreResourcesLevel += 1;
                    break;
                default:
                    break;
            }

            // TODO: Constants
            player.Points.PointsPlanet += 150;

            player.Technologies.CurrentlyResearching = CurrentlyResearching.None;
            player.Technologies.StartTime = null;
            player.Technologies.EndTime = null;

            this.users.Update(user);
            this.users.SaveChanges();
        }

        public Technologies GetPlayerTechnologies(string userId)
        {
            var user = this.users
                     .All()
                     .Include(x => x.PlayerObject)
                     .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return null;
            }

            return user.PlayerObject.Technologies;
        }

        private bool CanResearch(PlayerObject pO, int toLevel, ITechnology techLogic)
        {
            if (pO.Technologies.CurrentlyResearching != CurrentlyResearching.None)
            {
                return false;
            }

            if (toLevel > techLogic.MaxLevel)
            {
                return false;
            }

            if (pO.Buildings.ResearchCentreLevel < techLogic.Prerequisite)
            {
                return false;
            }

            var requiredResources = techLogic.GetRequiredResources(toLevel);

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
