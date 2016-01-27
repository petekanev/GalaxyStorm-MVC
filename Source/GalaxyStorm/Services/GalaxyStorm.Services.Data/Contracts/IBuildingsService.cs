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

        void CompleteBuildHeadQuarters(string userId);

        void CompleteBuildBarracks(string userId);

        void CompleteBuildResearchCentre(string userId);

        void CompleteBuildSolarCollector(string userId);

        void CompleteBuildCrystalExtractor(string userId);

        void CompleteBuildMetalScrapper(string userId);
    }
}
