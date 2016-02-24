namespace GalaxyStorm.Services.Data.Contracts
{
    using System;
    using System.Linq;
    using GalaxyStorm.Data.Models;
    using GalaxyStorm.Data.Models.PlayerObjects;

    public interface IPlayerService : IService
    {
        void ReassignPlayerObject(string userId);

        void AssignUnassignedUsers();

        void AssignPlayerObject(ApplicationUser user);

        void AssignPlayerObjectWithShard(ApplicationUser user, int shardId);

        void AssignUserToPlayerObject(string userId);

        void AssignPlayerObjectToPlanet(string userId);
        
        Resources GetPlayerResources(string userId);

        long[] GetHourlyResourceIncome(string userId);

        PlayerObject GetPlayerInformation(string userId);

        IQueryable<PlayerObject> GetPlayers();

        void UpdateResources(string poId, long energy, long crystal, long metal);
    }
}
