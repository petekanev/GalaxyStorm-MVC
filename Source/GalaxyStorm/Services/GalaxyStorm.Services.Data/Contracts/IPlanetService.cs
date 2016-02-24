namespace GalaxyStorm.Services.Data.Contracts
{
    using GalaxyStorm.Data.Models;

    public interface IPlanetService : IService
    {
        Planet GetPlayerPlanet(string userId);

        Planet GetPublicPlanet(string userId, string shardName, string planetName);
    }
}
