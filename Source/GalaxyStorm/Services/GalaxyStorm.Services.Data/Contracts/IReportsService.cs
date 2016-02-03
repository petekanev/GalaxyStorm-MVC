namespace GalaxyStorm.Services.Data.Contracts
{
    using System;
    using System.Linq;
    using GalaxyStorm.Data.Models.PlayerObjects;

    public interface IReportsService
    {
        void CreateReport(string userId, Report report);

        IQueryable<Report> AllReports(string userId);

        IQueryable<Report> UnreadReports(string userId);

        void Broadcast(Report report);

        void BroadcastToShard(int shardId, Report report);
    }
}
