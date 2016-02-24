namespace GalaxyStorm.Services.Data.Contracts
{
    using System.Linq;
    using GalaxyStorm.Data.Models;

    public interface IPlanetService : IService
    {
        Planet GetPlayerPlanet(string userId);

        Planet GetPublicPlanet(string userId, string shardName, string planetName);

        Planet GetPrivatePlanet(string shardName, string planetName);

        IQueryable<Planet> GetPlanetsByShardId(int shardId);
    }
}
