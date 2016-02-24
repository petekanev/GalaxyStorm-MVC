namespace GalaxyStorm.Web.Areas.Public.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using Infrastructure;
    using Services.Data.Contracts;
    using ViewModels.Info;

    public class InfoController : BaseController
    {
        private readonly IInfoService infoService;

        public InfoController(IInfoService infoService)
        {
            this.infoService = infoService;
        }

        // GET: Public/Info
        public ActionResult Index()
        {
            var topTen = this.Cache.Get("topLb", () => this.infoService
                .GetTopPlayersInShards(10)
                .ProjectTo<InfoLeaderboardsViewModel>()
                .ToList(), 60 * 30);

            return View(topTen);
        }

        public ActionResult TopPlanet()
        {
            var topFiveCombat = this.Cache.Get("topPlanetLb", () => this.infoService
                .GetTopPlayerWithPlanetPoints(5)
                .ProjectTo<InfoLeaderboardsViewModel>()
                .ToList(), 60 * 30);

            return PartialView(topFiveCombat);
        }

        public ActionResult TopNeutral()
        {
            var topFiveCombat = this.Cache.Get("topNeutralLb", () => this.infoService
                .GetTopPlayersWithNeutralPoints(5)
                .ProjectTo<InfoLeaderboardsViewModel>()
                .ToList(), 60 * 30);

            return PartialView(topFiveCombat);
        }

        public ActionResult TopCombat()
        {
            var topFiveCombat = this.Cache.Get("topCombatLb", () => this.infoService
                .GetTopPlayersWithCombatPoints(5)
                .ProjectTo<InfoLeaderboardsViewModel>()
                .ToList(), 60 * 30);

            return PartialView(topFiveCombat);
        }
    }
}