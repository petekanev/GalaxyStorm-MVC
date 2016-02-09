namespace GalaxyStorm.Web.Areas.Planet.Controllers
{
    using System.Web.Mvc;
    using Infrastructure;
    using Logic.Core;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels.Technologies;

    public class TechnologiesController : UsersController
    {
        private readonly IBuildingsService buildingsService;
        private readonly ITechnologiesService techService;
        private readonly ILogicProvider logic;

        public TechnologiesController(IBuildingsService buildingsService, ITechnologiesService techService, ILogicProvider logic)
        {
            this.buildingsService = buildingsService;
            this.techService = techService;
            this.logic = logic;
        }

        // GET: Planet/Technologies
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var rCLevel = this.buildingsService.GetPlayerBuildings(userId).ResearchCentreLevel;
            var technologies = this.techService.GetPlayerTechnologies(userId);

            var vM = new TechnologiesViewModel(technologies)
            {
                FasterConstruction = new TechnologyViewModel(technologies.FasterConstructionLevel, this.logic.Technologies.FasterConstruction),
                MoreResources = new TechnologyViewModel(technologies.MoreResourcesLevel, this.logic.Technologies.MoreResources),
                ArmoredFleet = new TechnologyViewModel(technologies.ArmoredFleetLevel, this.logic.Technologies.ArmoredFleet),
                CheaperFleet = new TechnologyViewModel(technologies.CheaperFleetLevel, this.logic.Technologies.CheaperFleet),
                LargerFleet = new TechnologyViewModel(technologies.LargerFleetLevel, this.logic.Technologies.LargerFleet)
            };

            return View(vM);
        }

        public ActionResult ArmoredFleet()
        {
            var userId = User.Identity.GetUserId();

            var rCLevel = this.buildingsService.GetPlayerBuildings(userId).ResearchCentreLevel;
            var technologies = this.techService.GetPlayerTechnologies(userId);

            var vM = new TechnologiesViewModel(rCLevel, technologies)
            {
                ArmoredFleet = new TechnologyViewModel(technologies.ArmoredFleetLevel, this.logic.Technologies.ArmoredFleet)
            };

            ViewBag.Title = vM.ArmoredFleet.Name;

            return View(vM);
        }

        public ActionResult LargerFleet()
        {
            var userId = User.Identity.GetUserId();

            var rCLevel = this.buildingsService.GetPlayerBuildings(userId).ResearchCentreLevel;
            var technologies = this.techService.GetPlayerTechnologies(userId);

            var vM = new TechnologiesViewModel(rCLevel, technologies)
            {
                LargerFleet = new TechnologyViewModel(technologies.ArmoredFleetLevel, this.logic.Technologies.LargerFleet)
            };

            ViewBag.Title = vM.ArmoredFleet.Name;

            return View(vM);
        }

        public ActionResult CheaperFleet()
        {
            var userId = User.Identity.GetUserId();

            var rCLevel = this.buildingsService.GetPlayerBuildings(userId).ResearchCentreLevel;
            var technologies = this.techService.GetPlayerTechnologies(userId);

            var vM = new TechnologiesViewModel(rCLevel, technologies)
            {
                CheaperFleet = new TechnologyViewModel(technologies.CheaperFleetLevel, this.logic.Technologies.CheaperFleet)
            };

            ViewBag.Title = vM.CheaperFleet.Name;

            return View(vM);
        }

        public ActionResult MoreResources()
        {
            var userId = User.Identity.GetUserId();

            var rCLevel = this.buildingsService.GetPlayerBuildings(userId).ResearchCentreLevel;
            var technologies = this.techService.GetPlayerTechnologies(userId);

            var vM = new TechnologiesViewModel(rCLevel, technologies)
            {
                MoreResources = new TechnologyViewModel(technologies.MoreResourcesLevel, this.logic.Technologies.MoreResources)
            };

            ViewBag.Title = vM.MoreResources.Name;

            return View(vM);
        }

        public ActionResult FasterConstruction()
        {
            var userId = User.Identity.GetUserId();

            var rCLevel = this.buildingsService.GetPlayerBuildings(userId).ResearchCentreLevel;
            var technologies = this.techService.GetPlayerTechnologies(userId);

            var vM = new TechnologiesViewModel(rCLevel, technologies)
            {
                FasterConstruction = new TechnologyViewModel(technologies.FasterConstructionLevel, this.logic.Technologies.FasterConstruction)
            };

            ViewBag.Title = vM.FasterConstruction.Name;

            return View(vM);
        }
    }
}