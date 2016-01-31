namespace GalaxyStorm.Services.Data.Contracts
{
    using System;

    public interface IBuildingsService
    {
        TimeSpan? ScheduleBuildHeadQuarters(string userId);

        TimeSpan? ScheduleBuildBarracks(string userId);

        TimeSpan? ScheduleResearchCentre(string userId);

        TimeSpan? ScheduleSolarCollector(string userId);

        TimeSpan? ScheduleCrystalExtractor(string userId);

        TimeSpan? ScheduleMetalScrapper(string userId);

        void CompleteBuilding(string userId);
    }
}
