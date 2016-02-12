namespace GalaxyStorm.Web.Areas.Planet.Controllers
{
    using System.Web.Mvc;
    using Hangfire;
    using Infrastructure;
    using Logic.Core;
    using Microsoft.AspNet.Identity;
    using Services.Data;
    using Services.Data.Contracts;
    using ViewModels.Technologies;

    public class TechnologiesController : UsersController
    {
        private readonly IBuildingsService buildingsService;
        private readonly ITechnologiesService techService;
        private readonly IPlayerService playerService;
        private readonly ILogicProvider logic;

        public TechnologiesController(IBuildingsService buildingsService, ITechnologiesService techService, IPlayerService playerService, ILogicProvider logic)
        {
            this.buildingsService = buildingsService;
            this.techService = techService;
            this.playerService = playerService;
            this.logic = logic;
        }

        // GET: Planet/Technologies
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var rCLevel = this.buildingsService.GetPlayerBuildings(userId).ResearchCentreLevel;
            var technologies = this.techService.GetPlayerTechnologies(userId);

            var vM = new TechnologiesViewModel(rCLevel, technologies)
            {
                FasterConstruction = new TechnologyViewModel(technologies.FasterConstructionLevel, this.logic.Technologies.FasterConstruction),
                MoreResources = new TechnologyViewModel(technologies.MoreResourcesLevel, this.logic.Technologies.MoreResources),
                ArmoredFleet = new TechnologyViewModel(technologies.ArmoredFleetLevel, this.logic.Technologies.ArmoredFleet),
                CheaperFleet = new TechnologyViewModel(technologies.CheaperFleetLevel, this.logic.Technologies.CheaperFleet),
                LargerFleet = new TechnologyViewModel(technologies.LargerFleetLevel, this.logic.Technologies.LargerFleet)
            };

            var reqRes = this.playerService.GetPlayerResources(userId);
            ViewBag.Energy = reqRes.Energy;
            ViewBag.Crystal = reqRes.Crystal;
            ViewBag.Metal = reqRes.Metal;

            return View(vM);
        }

        public ActionResult UpgradeArmoredFleet()
        {
            var userId = User.Identity.GetUserId();

            var timespan = this.techService.ScheduleResearchArmoredFleet(userId);

            if (timespan != null)
            {
                BackgroundJob.Schedule<TechnologiesService>(x => x.CompleteResearching(userId), timespan.Value);
            }
            else
            {
                this.SetErrorMessage();
            }

            return RedirectToAction("Index");
        }

        public ActionResult UpgradeCheaperFleet()
        {
            var userId = User.Identity.GetUserId();

            var timespan = this.techService.ScheduleResearchCheaperFleet(userId);

            if (timespan != null)
            {
                BackgroundJob.Schedule<TechnologiesService>(x => x.CompleteResearching(userId), timespan.Value);
            }
            else
            {
                this.SetErrorMessage();
            }

            return RedirectToAction("Index");
        }

        public ActionResult UpgradeLargerFleet()
        {
            var userId = User.Identity.GetUserId();

            var timespan = this.techService.ScheduleResearchLargerFleet(userId);

            if (timespan != null)
            {
                BackgroundJob.Schedule<TechnologiesService>(x => x.CompleteResearching(userId), timespan.Value);
            }
            else
            {
                this.SetErrorMessage();
            }

            return RedirectToAction("Index");
        }

        public ActionResult UpgradeFasterConstruction()
        {
            var userId = User.Identity.GetUserId();

            var timespan = this.techService.ScheduleResearchFasterConstruction(userId);

            if (timespan != null)
            {
                BackgroundJob.Schedule<TechnologiesService>(x => x.CompleteResearching(userId), timespan.Value);
            }
            else
            {
                this.SetErrorMessage();
            }

            return RedirectToAction("Index");
        }

        public ActionResult UpgradeMoreResources()
        {
            var userId = User.Identity.GetUserId();

            var timespan = this.techService.ScheduleResearchMoreResources(userId);

            if (timespan != null)
            {
                BackgroundJob.Schedule<TechnologiesService>(x => x.CompleteResearching(userId), timespan.Value);
            }
            else
            {
                this.SetErrorMessage();
            }

            return RedirectToAction("Index");
        }

        private void SetErrorMessage()
        {
            TempData["Error"] =
                "You cannot research this technology at the moment. You don't meet the requirements, or another research is in progress!";
        }
    }
}