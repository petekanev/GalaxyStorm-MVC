namespace GalaxyStorm.Services.Data.Contracts
{
    using System;
    using GalaxyStorm.Data.Models.PlayerObjects;

    public interface ITechnologiesService
    {
        TimeSpan? ScheduleResearchArmoredFleet(string userId);

        TimeSpan? ScheduleResearchCheaperFleet(string userId);

        TimeSpan? ScheduleResearchLargerFleet(string userId);

        TimeSpan? ScheduleResearchMoreResources(string userId);

        TimeSpan? ScheduleResearchFasterConstruction(string userId);

        void CompleteResearching(string userId);

        Technologies GetPlayerTechnologies(string userId);
    }
}
