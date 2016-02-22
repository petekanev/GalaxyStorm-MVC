namespace GalaxyStorm.Web.Areas.Admiral.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using Data;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data.Contracts;
    using Shard = Data.Models.Shard;

    public class ShardsController : Controller
    {
        private readonly IPlanetService planetService;
        private readonly IShardService shardService;

        public ShardsController(IPlanetService planetService, IShardService shardService)
        {
            this.planetService = planetService;
            this.shardService = shardService;
        }

        private GalaxyStormDbContext db = new GalaxyStormDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Shard> shards = db.Shards;
            DataSourceResult result = shards.ToDataSourceResult(request, shard => new {
                Id = shard.Id,
                Title = shard.Title,
                ShardSize = shard.ShardSize,
                BuildSpeed = shard.BuildSpeed,
                IsLocked = shard.IsLocked
            });

            return Json(result);
        }

        public ActionResult ReadPlanets([DataSourceRequest] DataSourceRequest request, int shardId)
        {
            
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, Shard shard)
        {
            if (ModelState.IsValid)
            {
                var entity = new Shard
                {
                    Id = shard.Id,
                    Title = shard.Title,
                    ShardSize = shard.ShardSize,
                    BuildSpeed = shard.BuildSpeed,
                    IsLocked = shard.IsLocked
                };

                db.Shards.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { shard }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
