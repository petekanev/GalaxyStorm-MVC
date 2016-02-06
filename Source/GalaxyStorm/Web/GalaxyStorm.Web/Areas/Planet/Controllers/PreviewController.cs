namespace GalaxyStorm.Web.Areas.Planet.Controllers
{
    using System;
    using System.Web.Mvc;
    using AutoMapper;
    using Infrastructure;
    using Logic.Core;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using ViewModels.Buildings;
    using ViewModels.Common;
    using Data.Models;
    using ViewModels.Technologies;

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

            var info = new CompletePlayerViewModel
            {
                Resources = new ResourcesViewModel
                {
                    Energy = pO.Resources.Energy,
                    Crystal = pO.Resources.Crystal,
                    Metal = pO.Resources.Metal,
                    EnergyPerHour = hourlyRes[0],
                    CrystalPerHour = hourlyRes[1],
                    MetalPerHour = hourlyRes[2]
                },
                Buildings = new BuildingsViewModel
                {
                    CurrentlyBuilding = pO.Buildings.CurrentlyBuilding.ToString(),
                    EndTime = pO.Buildings.EndTime,
                    StartTime = pO.Buildings.StartTime,
                    Headquarters = new BuildingViewModel(pO.Buildings.HeadQuartersLevel, this.logic.Buildings.Headquarters),
                    ResearchCentre = new BuildingViewModel(pO.Buildings.ResearchCentreLevel, this.logic.Buildings.ResearchCentre),
                    Barracks = new BuildingViewModel(pO.Buildings.BarracksLevel, this.logic.Buildings.Barracks),
                    SolarCollector = new BuildingViewModel(pO.Buildings.SolarCollectorLevel, this.logic.Buildings.SolarCollector),
                    CrystalExtractor = new BuildingViewModel(pO.Buildings.CrystalExtractorLevel, this.logic.Buildings.CrystalExtractor),
                    MetalScrapper = new BuildingViewModel(pO.Buildings.MetalScrapperLevel, this.logic.Buildings.MetalScrapper),
                },
                Technologies = new TechnologiesViewModel
                {
                    CurrentlyResearching = pO.Technologies.CurrentlyResearching.ToString(),
                    StartTime = pO.Technologies.StartTime,
                    EndTime = pO.Technologies.EndTime,
                    FasterConstruction = new TechnologyViewModel(pO.Technologies.FasterConstructionLevel, this.logic.Technologies.FasterConstruction),
                    MoreResources = new TechnologyViewModel(pO.Technologies.MoreResourcesLevel, this.logic.Technologies.MoreResources),
                    ArmoredFleet = new TechnologyViewModel(pO.Technologies.ArmoredFleetLevel, this.logic.Technologies.ArmoredFleet),
                    CheaperFleet = new TechnologyViewModel(pO.Technologies.CheaperFleetLevel, this.logic.Technologies.CheaperFleet),
                    LargerFleet = new TechnologyViewModel(pO.Technologies.LargerFleetLevel, this.logic.Technologies.LargerFleet)
                }
            };

            // Automapper mapping
            info.Planet = Mapper.Map<Planet, PlanetViewModel>(pO.Planet);

            // Manual calculations and mapping
            if (pO.Buildings.EndTime.HasValue)
            {
                var mins = pO.Buildings.EndTime.Value - DateTime.Now;
                info.Buildings.MinutesLeftToBuild = mins.TotalMinutes;

                var totalTime = pO.Buildings.EndTime.Value - pO.Buildings.StartTime.Value;
                var totalSegments = totalTime.TotalMinutes / 100;

                var percents = 100 - (info.Buildings.MinutesLeftToBuild / totalSegments);
                info.Buildings.PercentsBuilt = percents;
            }

            // TODO: Extract in service
            #region Specific Buildings Params
            // Headquarters
            info.Buildings.Headquarters.RequiredBuildTime = info.Buildings.Headquarters.Level <
                                                            info.Buildings.Headquarters.MaxLevel
                ? this.logic.Buildings.Headquarters.BuildTime[info.Buildings.Headquarters.Level + 1].TotalMinutes
                : 0;

            if (info.Buildings.Headquarters.Level < info.Buildings.Headquarters.MaxLevel)
            {
                var requiredResources =
                    this.logic.Buildings.Headquarters.GetRequiredResources(info.Buildings.Headquarters.Level + 1);

                info.Buildings.Headquarters.RequiredEnergy = requiredResources[0];
                info.Buildings.Headquarters.RequiredCrystals = requiredResources[1];
                info.Buildings.Headquarters.RequiredMetal = requiredResources[2];
            }

            // Research Centre
            info.Buildings.ResearchCentre.RequiredBuildTime = info.Buildings.ResearchCentre.Level <
                                                            info.Buildings.ResearchCentre.MaxLevel
                ? this.logic.Buildings.ResearchCentre.BuildTime[info.Buildings.ResearchCentre.Level + 1].TotalMinutes
                : 0;

            if (info.Buildings.Headquarters.Level < info.Buildings.Headquarters.MaxLevel)
            {
                var requiredResources =
                    this.logic.Buildings.ResearchCentre.GetRequiredResources(info.Buildings.ResearchCentre.Level + 1);

                info.Buildings.ResearchCentre.RequiredEnergy = requiredResources[0];
                info.Buildings.ResearchCentre.RequiredCrystals = requiredResources[1];
                info.Buildings.ResearchCentre.RequiredMetal = requiredResources[2];
            }

            // Barracks
            info.Buildings.Barracks.RequiredBuildTime = info.Buildings.Barracks.Level <
                                                            info.Buildings.Barracks.MaxLevel
                ? this.logic.Buildings.Barracks.BuildTime[info.Buildings.Barracks.Level + 1].TotalMinutes
                : 0;

            if (info.Buildings.Barracks.Level < info.Buildings.Barracks.MaxLevel)
            {
                var requiredResources =
                    this.logic.Buildings.Barracks.GetRequiredResources(info.Buildings.Barracks.Level + 1);

                info.Buildings.Barracks.RequiredEnergy = requiredResources[0];
                info.Buildings.Barracks.RequiredCrystals = requiredResources[1];
                info.Buildings.Barracks.RequiredMetal = requiredResources[2];
            }

            #endregion

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

            return View("_Resources", resVM);
        }
    }
}