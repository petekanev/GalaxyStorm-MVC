namespace GalaxyStorm.Services.Data.Contracts
{
    using System;
    using GalaxyStorm.Data.Models;
    using GalaxyStorm.Data.Models.PlayerObjects;

    public interface IPlayerService
    {
        void ReassignPlayerObject(string userId);

        void AssignPlayerObject(ApplicationUser user);

        void AssignPlayerObjectWithShard(ApplicationUser user, int shardId);

        Resources GetPlayerResources(string userId);
    }
}
