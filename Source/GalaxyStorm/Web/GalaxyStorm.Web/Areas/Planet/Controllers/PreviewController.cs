﻿namespace GalaxyStorm.Web.Areas.Planet.Controllers
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
                Buildings = new BuildingsViewModel(pO.Buildings)
                {
                    Headquarters = new BuildingViewModel(pO.Buildings.HeadQuartersLevel, this.logic.Buildings.Headquarters),
                    ResearchCentre = new BuildingViewModel(pO.Buildings.ResearchCentreLevel, this.logic.Buildings.ResearchCentre),
                    Barracks = new BuildingViewModel(pO.Buildings.BarracksLevel, this.logic.Buildings.Barracks),
                    SolarCollector = new ResourceBuildingViewModel(pO.Buildings.SolarCollectorLevel, this.logic.Buildings.SolarCollector),
                    CrystalExtractor = new ResourceBuildingViewModel(pO.Buildings.CrystalExtractorLevel, this.logic.Buildings.CrystalExtractor),
                    MetalScrapper = new ResourceBuildingViewModel(pO.Buildings.MetalScrapperLevel, this.logic.Buildings.MetalScrapper),
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