namespace GalaxyStorm.Services.Data.Contracts
{
    using System;
    using GalaxyStorm.Data.Models.PlayerObjects;

    public interface IFleetService
    {
        TimeSpan? ScheduleRecruitScout(string userId, int amount);

        TimeSpan? ScheduleRecruitCarrier(string userId, int amount);

        TimeSpan? ScheduleRecruitFighter(string userId, int amount);

        TimeSpan? ScheduleRecruitInterceptor(string userId, int amount);

        TimeSpan? ScheduleRecruitBomber(string userId, int amount);

        TimeSpan? ScheduleRecruitJuggernaut(string userId, int amount);

        void CompleteRecruiting(string userId);

        Units GetPlayerFleet(string userId);
    }
}
