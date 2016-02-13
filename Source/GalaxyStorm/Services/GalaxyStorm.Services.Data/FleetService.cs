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

    public class FleetService : IFleetService
    {
        private readonly IRepository<ApplicationUser> users;

        private readonly ILogicProvider logic;

        public FleetService(IRepository<ApplicationUser> users, ILogicProvider logic)
        {
            this.users = users;
            this.logic = logic;
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
    }
}
