namespace GalaxyStorm.Services.Data.Contracts
{
    using System;
    using GalaxyStorm.Data.Models;
    using GalaxyStorm.Data.Models.PlayerObjects;

    public interface IPlayerService
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
    }
}
