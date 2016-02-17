namespace GalaxyStorm.Services.Data.Contracts
{
    using GalaxyStorm.Data.Models;

    public interface IPlanetService
    {
        Planet GetPlayerPlanet(string userId);

        Planet GetPublicPlanet(string userId, string shardName, string planetName);
    }
}
