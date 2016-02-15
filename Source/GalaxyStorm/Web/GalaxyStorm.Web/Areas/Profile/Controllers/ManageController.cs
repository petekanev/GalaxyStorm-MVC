namespace GalaxyStorm.Web.Areas.Profile.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels.Common;

    public class ManageController : Controller
    {
        private readonly IReportsService reportsService;
        private readonly IPlayerService playerService;

        public ManageController(IReportsService reportsService, IPlayerService playerService)
        {
            this.reportsService = reportsService;
            this.playerService = playerService;
        }

        // GET: Profile/Manage
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var player = this.playerService.GetPlayerInformation(userId);

            // TODO: Optimize?
            var vM = new SimplePlayerViewModel
            {
                PlanetPoints = player.Points.PointsPlanet,
                NeutralPoints = player.Points.PointsNeutral,
                CombatPoints = player.Points.PointsCombat,

                CurrentlyBuilding = player.Buildings.CurrentlyBuilding.ToString(),
                CurrentlyResearching = player.Technologies.CurrentlyResearching.ToString(),
                CurrentlyRecruiting = "",

                NumberOfReports = player.Reports.Count(r => !r.IsRead),

                Planet = Mapper.Map<Planet, PlanetViewModel>(player.Planet)
            };

            return View(vM);
        }
    }
}