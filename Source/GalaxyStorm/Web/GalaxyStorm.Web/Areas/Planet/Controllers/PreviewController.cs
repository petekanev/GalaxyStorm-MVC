namespace GalaxyStorm.Web.Areas.Planet.Controllers
{
    using System;
    using System.Web.Mvc;
    using Infrastructure;
    using Logic.Core;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels.Buildings;
    using ViewModels.Common;

    public class PreviewController : UsersController
    {
        private readonly IPlayerService playerService;
        private readonly ILogicProvider logic;

        public PreviewController(IPlayerService playerService, ILogicProvider logic)
        {
            this.playerService = playerService;
            this.logic = logic;
        }

        // GET: Planet/Index
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var pO = this.playerService.GetPlayerInformation(userId);
            var hourlyRes = this.playerService.GetHourlyResourceIncome(userId);

            var info = new CompletePlayerViewModel();
            info.Resources = new ResourcesViewModel
            {
                Energy = pO.Resources.Energy,
                Crystal = pO.Resources.Crystal,
                Metal = pO.Resources.Metal,
                EnergyPerHour = hourlyRes[0],
                CrystalPerHour = hourlyRes[1],
                MetalPerHour = hourlyRes[2]
            };

            info.Buildings = new BuildingsViewModel
            {
                CurrentlyBuilding = pO.Buildings.CurrentlyBuilding.ToString(),
                ResearchCentreLevel = pO.Buildings.ResearchCentreLevel,
                BarracksLevel = pO.Buildings.BarracksLevel,
                SolarCollectorLevel = pO.Buildings.SolarCollectorLevel,
                CrystalExtractorLevel = pO.Buildings.CrystalExtractorLevel,
                MetalScrapperLevel = pO.Buildings.MetalScrapperLevel
            };

            info.Buildings.Headquarters = new HeadquartersViewModel
            {
                HeadquartersLevel = pO.Buildings.HeadQuartersLevel
            };

            if (pO.Buildings.EndTime.HasValue)
            {
                var mins = pO.Buildings.EndTime.Value - DateTime.Now;
                info.Buildings.MinutesLeftToBuild = mins.TotalMinutes;

                var totalTime = pO.Buildings.EndTime.Value - pO.Buildings.StartTime.Value;
                var totalSegments = totalTime.TotalMinutes / 100;

                var percents = 100 - (info.Buildings.MinutesLeftToBuild / totalSegments);
                info.Buildings.PercentsBuilt = percents;
            }

            return View(info);
        }

        public ActionResult Resources()
        {
            var userId = User.Identity.GetUserId();

            var res = this.playerService.GetPlayerResources(userId);
            var hourlyRes = this.playerService.GetHourlyResourceIncome(userId);

            var resVM = new ResourcesViewModel
            {
                Energy = res.Energy, 
                Crystal = res.Crystal, 
                Metal = res.Metal, 
                EnergyPerHour = hourlyRes[0], 
                CrystalPerHour = hourlyRes[1], 
                MetalPerHour = hourlyRes[2]
            };

            return View(resVM);
        }
    }
}