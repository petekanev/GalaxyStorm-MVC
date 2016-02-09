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
        private readonly IPlayerService playerService;
        private readonly ILogicProvider logic;

        public BuildingsController(IBuildingsService buildingsService, IPlayerService playerService, ILogicProvider logic)
        {
            this.buildingsService = buildingsService;
            this.playerService = playerService;
            this.logic = logic;
        }

        // GET: Planet/Buildings
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var buildings = this.buildingsService.GetPlayerBuildings(userId);
            var vM = new BuildingsViewModel(buildings)
            {
                Headquarters = new BuildingViewModel(buildings.HeadQuartersLevel, this.logic.Buildings.Headquarters),
                ResearchCentre = new BuildingViewModel(buildings.ResearchCentreLevel, this.logic.Buildings.ResearchCentre),
                Barracks = new BuildingViewModel(buildings.BarracksLevel, this.logic.Buildings.Barracks),
                SolarCollector = new ResourceBuildingViewModel(buildings.SolarCollectorLevel, this.logic.Buildings.SolarCollector),
                CrystalExtractor = new ResourceBuildingViewModel(buildings.CrystalExtractorLevel, this.logic.Buildings.CrystalExtractor),
                MetalScrapper = new ResourceBuildingViewModel(buildings.MetalScrapperLevel, this.logic.Buildings.MetalScrapper)
            };

            return View(vM);
        }

        public ActionResult Headquarters()
        {
            var userId = User.Identity.GetUserId();

            var buildings = this.buildingsService.GetPlayerBuildings(userId);
            var vM = new BuildingsViewModel(buildings) { Headquarters = new BuildingViewModel(buildings.HeadQuartersLevel, this.logic.Buildings.Headquarters)};

            var reqRes = this.playerService.GetPlayerResources(userId);
            ViewBag.Energy = reqRes.Energy;
            ViewBag.Crystal = reqRes.Crystal;
            ViewBag.Metal = reqRes.Metal;

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
            else
            {
                TempData["Error"] =
                    "You cannot upgrade this building at the moment. You don't meet the requirements, or another building is in progress...";
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

            var reqRes = this.playerService.GetPlayerResources(userId);
            ViewBag.Energy = reqRes.Energy;
            ViewBag.Crystal = reqRes.Crystal;
            ViewBag.Metal = reqRes.Metal;

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
            var userId = User.Identity.GetUserId();

            var buildings = this.buildingsService.GetPlayerBuildings(userId);
            var vM = new BuildingsViewModel(buildings)
            {
                Barracks = new BuildingViewModel(buildings.BarracksLevel, this.logic.Buildings.Barracks),
                // For prerequisite checks
                Headquarters = new BuildingViewModel { Level = buildings.HeadQuartersLevel }
            };

            var reqRes = this.playerService.GetPlayerResources(userId);
            ViewBag.Energy = reqRes.Energy;
            ViewBag.Crystal = reqRes.Crystal;
            ViewBag.Metal = reqRes.Metal;

            ViewBag.Title = vM.Barracks.Name;

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

            var reqRes = this.playerService.GetPlayerResources(userId);
            ViewBag.Energy = reqRes.Energy;
            ViewBag.Crystal = reqRes.Crystal;
            ViewBag.Metal = reqRes.Metal;

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
            var userId = User.Identity.GetUserId();

            var buildings = this.buildingsService.GetPlayerBuildings(userId);
            var vM = new BuildingsViewModel(buildings)
            {
                CrystalExtractor = new ResourceBuildingViewModel(buildings.CrystalExtractorLevel, this.logic.Buildings.CrystalExtractor),
                // For prerequisite checks
                Headquarters = new BuildingViewModel { Level = buildings.HeadQuartersLevel }
            };

            var reqRes = this.playerService.GetPlayerResources(userId);
            ViewBag.Energy = reqRes.Energy;
            ViewBag.Crystal = reqRes.Crystal;
            ViewBag.Metal = reqRes.Metal;

            ViewBag.Title = vM.CrystalExtractor.Name;

            return View(vM);
        }

        public ActionResult UpgradeCrystalExtractor()
        {
            var userId = User.Identity.GetUserId();

            var timespan = this.buildingsService.ScheduleCrystalExtractor(userId);

            // TODO: add alerts (in divs with TempData)
            if (timespan != null)
            {
                BackgroundJob.Schedule<BuildingService>(x => x.CompleteBuilding(userId), timespan.Value);
            }

            return RedirectToAction("CrystalExtractor");
        }

        public ActionResult MetalScrapper()
        {
            var userId = User.Identity.GetUserId();

            var buildings = this.buildingsService.GetPlayerBuildings(userId);
            var vM = new BuildingsViewModel(buildings)
            {
                MetalScrapper = new ResourceBuildingViewModel(buildings.MetalScrapperLevel, this.logic.Buildings.MetalScrapper),
                // For prerequisite checks
                Headquarters = new BuildingViewModel { Level = buildings.HeadQuartersLevel }
            };

            var reqRes = this.playerService.GetPlayerResources(userId);
            ViewBag.Energy = reqRes.Energy;
            ViewBag.Crystal = reqRes.Crystal;
            ViewBag.Metal = reqRes.Metal;

            ViewBag.Title = vM.MetalScrapper.Name;

            return View(vM);
        }

        public ActionResult UpgradeMetalScrapper()
        {
            var userId = User.Identity.GetUserId();

            var timespan = this.buildingsService.ScheduleMetalScrapper(userId);

            // TODO: add alerts (in divs with TempData)
            if (timespan != null)
            {
                BackgroundJob.Schedule<BuildingService>(x => x.CompleteBuilding(userId), timespan.Value);
            }

            return RedirectToAction("MetalScrapper");
        }
    }
}