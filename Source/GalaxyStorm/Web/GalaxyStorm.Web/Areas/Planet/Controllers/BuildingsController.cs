namespace GalaxyStorm.Web.Areas.Planet.Controllers
{
    using System.Web.Mvc;
    using Hangfire;
    using Infrastructure;
    using Logic.Core;
    using Microsoft.AspNet.Identity;
    using Services.Data;
    using Services.Data.Contracts;
    using ViewModels.Buildings;

    public class BuildingsController : UsersController
    {
        private readonly IBuildingsService buildingsService;
        private readonly ILogicProvider logic;

        public BuildingsController(IBuildingsService buildingsService, ILogicProvider logic)
        {
            this.buildingsService = buildingsService;
            this.logic = logic;
        }

        // GET: Planet/Buildings
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Headquarters()
        {
            var userId = User.Identity.GetUserId();

            var buildings = this.buildingsService.GetPlayerBuildings(userId);
            var vM = new BuildingsViewModel(buildings) { Headquarters = new BuildingViewModel(buildings.HeadQuartersLevel, this.logic.Buildings.Headquarters)};

            ViewBag.Title = vM.Headquarters.Name;

            return View(vM);
        }

        public ActionResult UpgradeHeadquarters()
        {
            var userId = User.Identity.GetUserId();

            var timespan = this.buildingsService.ScheduleBuildHeadQuarters(userId);

            // TODO: add alerts (in divs with TempData)
            if (timespan != null)
            {
                BackgroundJob.Schedule<BuildingService>(x => x.CompleteBuilding(userId), timespan.Value);
            }

            return RedirectToAction("Headquarters");
        }

        public ActionResult ResearchCentre()
        {
            var userId = User.Identity.GetUserId();

            var buildings = this.buildingsService.GetPlayerBuildings(userId);
            var vM = new BuildingsViewModel(buildings)
            {
                ResearchCentre = new BuildingViewModel(buildings.ResearchCentreLevel, this.logic.Buildings.ResearchCentre),
                // For prerequisite checks
                Headquarters = new BuildingViewModel { Level = buildings.HeadQuartersLevel}
            };

            ViewBag.Title = vM.ResearchCentre.Name;

            return View(vM);
        }

        public ActionResult UpgradeResearchCentre()
        {
            var userId = User.Identity.GetUserId();

            var timespan = this.buildingsService.ScheduleResearchCentre(userId);

            // TODO: add alerts (in divs with TempData)
            if (timespan != null)
            {
                BackgroundJob.Schedule<BuildingService>(x => x.CompleteBuilding(userId), timespan.Value);
            }

            return RedirectToAction("ResearchCentre");
        }

        public ActionResult Barracks()
        {
            ViewBag.Title = "Barracks";

            return View();
        }

        public ActionResult SolarCollector()
        {
            var userId = User.Identity.GetUserId();

            var buildings = this.buildingsService.GetPlayerBuildings(userId);
            var vM = new BuildingsViewModel(buildings)
            {
                SolarCollector = new ResourceBuildingViewModel(buildings.SolarCollectorLevel, this.logic.Buildings.SolarCollector),
                // For prerequisite checks
                Headquarters = new BuildingViewModel { Level = buildings.HeadQuartersLevel }
            };

            ViewBag.Title = vM.SolarCollector.Name;

            return View(vM);
        }

        public ActionResult UpgradeSolarCollector()
        {
            var userId = User.Identity.GetUserId();

            var timespan = this.buildingsService.ScheduleSolarCollector(userId);

            // TODO: add alerts (in divs with TempData)
            if (timespan != null)
            {
                BackgroundJob.Schedule<BuildingService>(x => x.CompleteBuilding(userId), timespan.Value);
            }

            return RedirectToAction("SolarCollector");
        }

        public ActionResult CrystalExtractor()
        {
            ViewBag.Title = "Crystal Extractor";

            return View();
        }

        public ActionResult MetalScrapper()
        {
            ViewBag.Title = "Metal Scrapper";

            return View();
        }
    }
}