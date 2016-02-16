namespace GalaxyStorm.ViewModels.Common
{
    using System;
    using AutoMapper;
    using Data.Models;
    using GalaxyStorm.Common.Contracts;

    public class PublicPlanetViewModel : IMapFrom<Planet>, ICustomMapFor
    {
        public int X { get; set; }

        public int Y { get; set; }

        public string Title { get; set; }

        public bool IsPopulated { get; set; }

        public string PlayerDisplayName { get; set; }

        public int PlayerPoints { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Planet, PublicPlanetViewModel>()
                .ForMember(x => x.PlayerPoints,
                    opts =>
                        opts.MapFrom(
                            p =>
                                p.PlayerObject.Points.PointsNeutral + p.PlayerObject.Points.PointsCombat +
                                p.PlayerObject.Points.PointsPlanet))
                .ForMember(x => x.PlayerDisplayName,
                    opts => opts.MapFrom(pl => pl.PlayerObject.ApplicationUser.DisplayName));
        }
    }
}