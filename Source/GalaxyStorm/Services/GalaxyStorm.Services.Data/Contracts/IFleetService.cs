namespace GalaxyStorm.Services.Data.Contracts
{
    using System;
    using GalaxyStorm.Data.Models.PlayerObjects;

    public interface IFleetService
    {
        Units GetPlayerFleet(string userId);
    }
}
