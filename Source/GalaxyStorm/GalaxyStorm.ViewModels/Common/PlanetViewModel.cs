namespace GalaxyStorm.ViewModels.Common
{
    using System;
    using AutoMapper;
    using Data.Models;
    using GalaxyStorm.Common.Contracts;

    public class PlanetViewModel : IMapFrom<Planet>, ICustomMapFor
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public double EnergyModifier { get; set; }

        public double CrystalModifier { get; set; }

        public double MetalModifier { get; set; }

        public string ShardTitle { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Planet, PlanetViewModel>()
                .ForMember(planet => planet.ShardTitle, opts => opts.MapFrom(x => x.Shard.Title));
        }
    }
}
