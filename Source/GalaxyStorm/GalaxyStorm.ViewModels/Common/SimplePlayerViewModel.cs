namespace GalaxyStorm.ViewModels.Common
{
    using System;
    using System.Linq;
    using AutoMapper;
    using Data.Models.PlayerObjects;
    using GalaxyStorm.Common.Contracts;

    public class SimplePlayerViewModel : IMapFrom<PlayerObject>, ICustomMapFor
    {
        public string DisplayName { get; set; }

        public int NumberOfReports { get; set; }

        public int PlanetPoints { get; set; }

        public int NeutralPoints { get; set; }

        public int CombatPoints { get; set; }

        public PlanetViewModel Planet { get; set; }

        public string CurrentlyBuilding { get; set; }

        public string CurrentlyResearching { get; set; }

        public string CurrentlyRecruiting { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<PlayerObject, SimplePlayerViewModel>()
                .ForMember(x => x.DisplayName, opts => opts.MapFrom(pO => pO.ApplicationUser.DisplayName))
                .ForMember(x => x.NumberOfReports, opts => opts.MapFrom(r => r.Reports.Count(y => !y.IsRead)))
                .ForMember(x => x.PlanetPoints, opts => opts.MapFrom(pl => pl.Points.PointsPlanet))
                .ForMember(x => x.NeutralPoints, opts => opts.MapFrom(pl => pl.Points.PointsNeutral))
                .ForMember(x => x.CombatPoints, opts => opts.MapFrom(pl => pl.Points.PointsCombat))
                .ForMember(x => x.CurrentlyBuilding, opts => opts.MapFrom(b => b.Buildings.CurrentlyBuilding.ToString()))
                .ForMember(x => x.CurrentlyResearching,
                    opts => opts.MapFrom(r => r.Technologies.CurrentlyResearching.ToString()))
                .ForMember(x => x.CurrentlyRecruiting, opts => opts.MapFrom(b => b.Units.CurrentlyRecruiting.ToString()));
        }
    }
}
