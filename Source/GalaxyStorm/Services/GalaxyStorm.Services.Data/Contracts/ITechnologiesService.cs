namespace GalaxyStorm.Services.Data.Contracts
{
    using GalaxyStorm.Data.Models.PlayerObjects;

    public interface ITechnologiesService
    {
        Technologies GetPlayerTechnologies(string userId);
    }
}
