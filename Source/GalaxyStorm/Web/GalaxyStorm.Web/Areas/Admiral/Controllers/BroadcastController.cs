namespace GalaxyStorm.Web.Areas.Admiral.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Infrastructure;
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
            var allShards = this.shardService.GetShards()
                .ProjectTo<SimpleShardViewModel>()
                .ToList();

            ViewBag.Shards = allShards;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Broadcast(ReportInputModel model)
        {
            if (!ModelState.IsValid)
            {
                var allShards = this.shardService.GetShards()
                    .ProjectTo<SimpleShardViewModel>()
                    .ToList();

                ViewBag.Shards = allShards;

                return View("Index", model);
            }

            this.SetSuccessMessage();

            return RedirectToAction("Index");
        }

        private void SetSuccessMessage()
        {
            TempData["Success"] = "The message will be sent out to all players in the shard.";
        }
    }
}