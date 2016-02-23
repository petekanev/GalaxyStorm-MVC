namespace GalaxyStorm.Web.Areas.Admiral.Controllers
{
    using System.Web.Mvc;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data.Models;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data.Contracts;
    using ViewModels.Common;
    using ViewModels.Shards;

    public class ShardsController : Controller
    {
        private readonly IPlanetService planetService;
        private readonly IShardService shardService;

        public ShardsController(IPlanetService planetService, IShardService shardService)
        {
            this.planetService = planetService;
            this.shardService = shardService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            var shards = this.shardService.GetShards().ProjectTo<SimpleShardViewModel>();
            
            DataSourceResult result = shards.ToDataSourceResult(request);

            return Json(result);
        }

        public ActionResult ReadPlanets([DataSourceRequest] DataSourceRequest request, int shardId)
        {
            var planets = this.planetService.GetPlanetsByShardId(shardId).ProjectTo<PlayerPlanetViewModel>();

            var result = planets.ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, SimpleShardViewModel shard)
        {
            if (ModelState.IsValid)
            {
                var mappedShard = Mapper.Map<Shard>(shard);

                this.shardService.UpdateShard(mappedShard);
            }

            return Json(new[] { shard }.ToDataSourceResult(request, ModelState));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return null;
        }

        [HttpPost]
        public ActionResult Create(Shard shard)
        {
            return null;
        }
    }
}
