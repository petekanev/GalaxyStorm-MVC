namespace GalaxyStorm.Web.Areas.Admiral.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Web.Mvc;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data.Models.PlayerObjects;
    using Hangfire;
    using Infrastructure;
    using Services.Data;
    using Services.Data.Contracts;
    using ViewModels.Reports;
    using ViewModels.Shards;

    public class BroadcastController : AdminController
    {
        private readonly IShardService shardService;
        private readonly IReportsService reportsService;

        public BroadcastController(IShardService shardService, IReportsService reportsService)
        {
            this.shardService = shardService;
            this.reportsService = reportsService;
        }

        // GET: AdmiralsQuarters/Broadcast
        public ActionResult Index(ReportInputModel model)
        {
            var allShards = this.Cache.Get<IEnumerable<SimpleShardViewModel>>(
                "AllShards",
                () => this.shardService.GetShards()
                .ProjectTo<SimpleShardViewModel>()
                .ToList(),
                60 * 60);

            ViewBag.Shards = allShards;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Broadcast(ReportInputModel model)
        {
            if (!ModelState.IsValid)
            {
                var allShards = this.Cache.Get<IEnumerable<SimpleShardViewModel>>(
                    "AllShards",
                    () => this.shardService.GetShards()
                    .ProjectTo<SimpleShardViewModel>()
                    .ToList(),
                    60 * 60);

                ViewBag.Shards = allShards;

                return View("Index", model);
            }

            this.SetSuccessMessage();

            var report = Mapper.Map<Report>(model);

            BackgroundJob.Enqueue<IReportsService>(rs => rs.BroadcastToShard(model.ShardId, report));

            return RedirectToAction("Index");
        }

        private void SetSuccessMessage()
        {
            TempData["Success"] = "The message will be sent out to all players in the shard.";
        }
    }
}