namespace GalaxyStorm.Services.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Contracts;
    using GalaxyStorm.Data.Models;
    using GalaxyStorm.Data.Models.PlayerObjects;
    using GalaxyStorm.Data.Repositories;

    public class ReportsService : IReportsService
    {
        private readonly IRepository<ApplicationUser> users;
        private readonly IRepository<Report> reports;

        public ReportsService(IRepository<ApplicationUser> users, IRepository<Report> reports)
        {
            this.users = users;
            this.reports = reports;
        }

        public void CreateReport(string userId, Report report)
        {
            var user = this.users
               .All()
               .Include(x => x.PlayerObject)
               .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return;
            }

            report.ReceivedOn = DateTime.Now;

            user.PlayerObject.Reports.Add(report);
            this.users.Update(user);
            this.users.SaveChanges();
        }

        public IQueryable<Report> AllReports(string userId)
        {
            var user = this.users
                 .All()
                 .Include(x => x.PlayerObject)
                 .FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return null;
            }

            return user.PlayerObject.Reports.AsQueryable();
        }

        public IQueryable<Report> UnreadReports(string userId)
        {
            return this.AllReports(userId).Where(x => !x.IsRead);
        }

        public void MarkAsRead(int reportId)
        {
            var report = this.reports.All().FirstOrDefault(r => r.Id == reportId);

            if (report == null)
            {
                return;
            }

            report.IsRead = true;
            reports.Update(report);
            reports.SaveChanges();
        }

        public void Broadcast(Report report)
        {
            var usersToBroadCastTo = this.users
                .All()
                .Include(x => x.PlayerObject);

            foreach (var user in usersToBroadCastTo)
            {
                user.PlayerObject.Reports.Add(report);
                this.users.Update(user);
            }

            this.users.SaveChanges();
        }

        public void BroadcastToShard(int shardId, Report report)
        {
            var usersToBroadCastTo = this.users
                   .All()
                   .Include(x => x.PlayerObject)
                   .Where(x => x.PlayerObject.Planet.ShardId == shardId);

            foreach (var user in usersToBroadCastTo)
            {
                user.PlayerObject.Reports.Add(report);
                this.users.Update(user);
            }

            this.users.SaveChanges();
        }
    }
}
