namespace GalaxyStorm.Web.Areas.Shard.Controllers
{
    using System.Web.Mvc;
    using AutoMapper;
    using Infrastructure;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels.Common;

    public class PreviewController : UsersController
    {
        private readonly IShardService shardService;
        private readonly IPlanetService planetService;

        public PreviewController(IShardService shardService, IPlanetService planetService)
        {
            this.shardService = shardService;
            this.planetService = planetService;
        }

        // GET: Shard/Preview
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var currentShard = this.shardService.GetShardByPlayerId(userId);

            var currentPlayerPlanet = planetService.GetPlayerPlanet(userId);

            ViewData["PlayerPlanet"] = currentPlayerPlanet.Title;

            var vM = Mapper.Map<PublicShardViewModel>(currentShard);

            return View(vM);
        }
    }
}