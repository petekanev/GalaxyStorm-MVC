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
    using Logic.Core.Ships;
    using Logic.Core.Technologies;

    public class FleetService : IFleetService
    {
        private readonly IRepository<ApplicationUser> users;

        private readonly ILogicProvider logic;

        public FleetService(IRepository<ApplicationUser> users, ILogicProvider logic)
        {
            this.users = users;
            this.logic = logic;
        }

        public TimeSpan? ScheduleRecruitScout(string userId, int amount)
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

            if (!this.CanRecruit(player, amount, this.logic.Ships.Scout, this.logic.Technologies.CheaperFleet))
            {
                return null;
            }
            else
            {
                var requiredResources = this.logic.Ships.Scout.RequiredResourcesToBuild;

                this.SubstractResources(player, requiredResources, amount, this.logic.Technologies.CheaperFleet);

                var fasterConstructionLevel = player.Technologies.FasterConstructionLevel;
                var fasterConstructionModifier =
                    this.logic.Technologies.FasterConstruction.Modifier[fasterConstructionLevel];

                var timespanToRecruitBeforeTech = TimeSpan.FromTicks((long) (this.logic.Ships.Scout.BuildTime.Ticks*amount * player.Planet.Shard.BuildSpeed));

                var timespan = timespanToRecruitBeforeTech -
                               TimeSpan.FromTicks((long) (timespanToRecruitBeforeTech.Ticks*fasterConstructionModifier));

                player.Units.CurrentlyRecruiting = CurrentlyRecruiting.Scout;
                player.Units.StartTime = DateTime.Now;
                player.Units.EndTime = DateTime.Now.AddTicks(timespan.Ticks);
                player.Units.AmountRecruiting = amount;

                this.users.Update(user);
                this.users.SaveChanges();

                return timespan;
            }
        }

        public TimeSpan? ScheduleRecruitCarrier(string userId, int amount)
        {
            throw new NotImplementedException();
        }

        public TimeSpan? ScheduleRecruitFighter(string userId, int amount)
        {
            throw new NotImplementedException();
        }

        public TimeSpan? ScheduleRecruitInterceptor(string userId, int amount)
        {
            throw new NotImplementedException();
        }

        public TimeSpan? ScheduleRecruitBomber(string userId, int amount)
        {
            throw new NotImplementedException();
        }

        public TimeSpan? ScheduleRecruitJuggernaut(string userId, int amount)
        {
            throw new NotImplementedException();
        }

        public void CompleteRecruiting(string userId)
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

            switch (player.Units.CurrentlyRecruiting)
            {
                    case CurrentlyRecruiting.Scout:
                    player.Units.ScoutsQuantity += player.Units.AmountRecruiting;
                    player.Points.PointsNeutral += this.logic.Ships.Scout.PointsOnRecruit * player.Units.AmountRecruiting;
                    break;
                    case CurrentlyRecruiting.Carrier:
                    player.Units.CarriersQuantity += player.Units.AmountRecruiting;
                    player.Points.PointsNeutral += this.logic.Ships.Carrier.PointsOnRecruit * player.Units.AmountRecruiting;
                    break;
                    case CurrentlyRecruiting.Fighter:
                    player.Units.FighterQuantity += player.Units.AmountRecruiting;
                    player.Points.PointsNeutral += this.logic.Ships.Fighter.PointsOnRecruit * player.Units.AmountRecruiting;
                    break;
                    case CurrentlyRecruiting.Interceptor:
                    player.Units.InterceptorQuantity += player.Units.AmountRecruiting;
                    player.Points.PointsNeutral += this.logic.Ships.Interceptor.PointsOnRecruit * player.Units.AmountRecruiting;
                    break;
                    case CurrentlyRecruiting.Bomber:
                    player.Units.BomberQuantity += player.Units.AmountRecruiting;
                    player.Points.PointsNeutral += this.logic.Ships.Bomber.PointsOnRecruit * player.Units.AmountRecruiting;
                    break;
                    case CurrentlyRecruiting.Juggernaut:
                    player.Units.JuggernautQuantity += player.Units.AmountRecruiting;
                    player.Points.PointsNeutral += this.logic.Ships.Juggernaut.PointsOnRecruit * player.Units.AmountRecruiting;
                    break;
                default:
                    break;
            }

            player.Units.CurrentlyRecruiting = CurrentlyRecruiting.None;
            player.Units.StartTime = null;
            player.Units.EndTime = null;
            player.Units.AmountRecruiting = 0;

            this.users.Update(user);
            this.users.SaveChanges();
        }

        public Units GetPlayerFleet(string userId)
        {
            var user = this.users
                .All()
                .Include(x => x.PlayerObject)
                .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return null;
            }

            return user.PlayerObject.Units;
        }

        private bool CanRecruit(PlayerObject pO, int amount, IShip shipLogic, ITechnology techLogic)
        {
            if (pO.Units.CurrentlyRecruiting != CurrentlyRecruiting.None)
            {
                return false;
            }

            if (amount <= 0)
            {
                return false;
            }

            if (pO.Buildings.BarracksLevel < shipLogic.Prerequisite)
            {
                return false;
            }

            var requiredResources = shipLogic.RequiredResourcesToBuild;
            var cheaperFleetModifier = techLogic.Modifier[pO.Technologies.CheaperFleetLevel];

            var requiredEnergy = (requiredResources[0] - (int) (cheaperFleetModifier*requiredResources[0]))*amount;
            var requiredCrystals = (requiredResources[1] - (int)(cheaperFleetModifier * requiredResources[1])) * amount;
            var requiredMetal = (requiredResources[2] - (int)(cheaperFleetModifier * requiredResources[2])) * amount;

            return pO.Resources.Energy > requiredEnergy
                   && pO.Resources.Crystal > requiredCrystals
                   && pO.Resources.Metal > requiredMetal;
        }

        private void SubstractResources(PlayerObject pO, int[] resources, int amount, ITechnology techLogic)
        {
            if (resources.Length < 3)
            {
                throw new ArgumentException();
            }

            var cheaperFleetModifier = techLogic.Modifier[pO.Technologies.CheaperFleetLevel];

            var requiredEnergy = (resources[0] - (int)(cheaperFleetModifier * resources[0])) * amount;
            var requiredCrystals = (resources[1] - (int)(cheaperFleetModifier * resources[1])) * amount;
            var requiredMetal = (resources[2] - (int)(cheaperFleetModifier * resources[2])) * amount;

            pO.Resources.Energy -= requiredEnergy;
            pO.Resources.Crystal -= requiredCrystals;
            pO.Resources.Metal -= requiredMetal;
        }
    }
}
