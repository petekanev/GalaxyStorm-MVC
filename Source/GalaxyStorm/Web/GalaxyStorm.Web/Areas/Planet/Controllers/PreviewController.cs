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
                    Headquarters = new HeadquartersViewModel
                    {
                        Level = pO.Buildings.HeadQuartersLevel,
                        Name = this.logic.Buildings.Headquarters.Name,
                        MaxLevel = this.logic.Buildings.Headquarters.MaxLevel,
                        Description = this.logic.Buildings.Headquarters.Description
                    },
                    ResearchCentre = new ResearchCentreViewModel
                    {
                        Level = pO.Buildings.ResearchCentreLevel,
                        Name = this.logic.Buildings.ResearchCentre.Name,
                        MaxLevel = this.logic.Buildings.ResearchCentre.MaxLevel,
                        Description = this.logic.Buildings.ResearchCentre.Description,
                        Prerequisites = this.logic.Buildings.ResearchCentre.Prerequisite
                    },
                    Barracks = new BarracksViewModel
                    {
                        Level = pO.Buildings.BarracksLevel,
                        Name = this.logic.Buildings.Barracks.Name,
                        MaxLevel = this.logic.Buildings.Barracks.MaxLevel,
                        Description = this.logic.Buildings.Barracks.Description,
                        Prerequisites = this.logic.Buildings.Barracks.Prerequisite
                    },
                    SolarCollector = new SolarCollectorViewModel
                    {
                        Level = pO.Buildings.SolarCollectorLevel,
                        Name = this.logic.Buildings.SolarCollector.Name,
                        MaxLevel = this.logic.Buildings.SolarCollector.MaxLevel,
                        Description = this.logic.Buildings.SolarCollector.Description,
                        Prerequisites = this.logic.Buildings.SolarCollector.Prerequisite 
                    },
                    CrystalExtractor = new CrystalExtractorViewModel
                    {
                        Level = pO.Buildings.CrystalExtractorLevel,
                        Name = this.logic.Buildings.CrystalExtractor.Name,
                        MaxLevel = this.logic.Buildings.CrystalExtractor.MaxLevel,
                        Description = this.logic.Buildings.CrystalExtractor.Description,
                        Prerequisites = this.logic.Buildings.CrystalExtractor.Prerequisite
                    },
                    MetalScrapper = new MetalScrapperViewModel
                    {
                        Level = pO.Buildings.MetalScrapperLevel,
                        Name = this.logic.Buildings.MetalScrapper.Name,
                        MaxLevel = this.logic.Buildings.MetalScrapper.MaxLevel,
                        Description = this.logic.Buildings.MetalScrapper.Description,
                        Prerequisites = this.logic.Buildings.MetalScrapper.Prerequisite
                    }
                },
                Technologies = new TechnologiesViewModel
                {
                    ArmoredFleet = new ArmoredFleetViewModel
                    {
                        Level = pO.Technologies.ArmoredFleetLevel,
                        Name = this.logic.Technologies.ArmoredFleet.Name,
                        MaxLevel = this.logic.Technologies.ArmoredFleet.MaxLevel,
                        Description = this.logic.Technologies.ArmoredFleet.Description,
                        Prerequisite = this.logic.Technologies.ArmoredFleet.Prerequisite
                    },
                    CheaperFleet = new CheaperFleetViewModel
                    {
                        Level = pO.Technologies.CheaperFleetLevel,
                        Name = this.logic.Technologies.CheaperFleet.Name,
                        MaxLevel = this.logic.Technologies.CheaperFleet.MaxLevel,
                        Description = this.logic.Technologies.CheaperFleet.Description,
                        Prerequisite = this.logic.Technologies.CheaperFleet.Prerequisite
                    },
                    LargerFleet = new LargerFleetViewModel
                    {
                        Level = pO.Technologies.LargerFleetLevel,
                        Name = this.logic.Technologies.LargerFleet.Name,
                        MaxLevel = this.logic.Technologies.LargerFleet.MaxLevel,
                        Description = this.logic.Technologies.LargerFleet.Description,
                        Prerequisite = this.logic.Technologies.LargerFleet.Prerequisite
                    }
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
                ? this.logic.Buildings.Headquarters.BuildTime[info.Buildings.Headquarters.Level+1].TotalMinutes
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

            return View(resVM);
        }
    }
}