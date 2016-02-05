namespace GalaxyStorm.Web.Areas.Planet.Controllers
{
    using System;
    using System.Web.Mvc;
    using Infrastructure;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels.Common;

    public class PreviewController : UsersController
    {
        private readonly IPlayerService playerService;

        public PreviewController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        // GET: Planet/Index
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var pO = this.playerService.GetPlayerInformation(userId);
            var hourlyRes = this.playerService.GetHourlyResourceIncome(userId);

            var info = new CompletePlayerViewModel
            {
                Energy = pO.Resources.Energy,
                Crystal = pO.Resources.Crystal,
                Metal = pO.Resources.Metal,
                EnergyPerHour = hourlyRes[0],
                CrystalPerHour = hourlyRes[1],
                MetalPerHour = hourlyRes[2],
                CurrentlyBuilding = pO.Buildings.CurrentlyBuilding.ToString(),
                HeadquartersLevel = pO.Buildings.HeadQuartersLevel,
                ResearchCentreLevel = pO.Buildings.ResearchCentreLevel,
                BarracksLevel = pO.Buildings.BarracksLevel,
                SolarCollectorLevel = pO.Buildings.SolarCollectorLevel,
                CrystalExtractorLevel = pO.Buildings.CrystalExtractorLevel,
                MetalScrapperLevel = pO.Buildings.MetalScrapperLevel
            };

            if (pO.Buildings.EndTime.HasValue)
            {
                var mins = pO.Buildings.EndTime.Value - DateTime.Now;
                info.MinutesToBuild = mins.TotalMinutes;
            }

            return View(info);
        }

        public ActionResult Resources()
        {
            var userId = User.Identity.GetUserId();

            var res = this.playerService.GetPlayerResources(userId);
            var hourlyRes = this.playerService.GetHourlyResourceIncome(userId);

            var resVM = new ResourcesViewModel { Energy = res.Energy, Crystal = res.Crystal, Metal = res.Metal, EnergyPerHour = hourlyRes[0], CrystalPerHour = hourlyRes[1], MetalPerHour = hourlyRes[2]};

            return View(resVM);
        }
    }
}