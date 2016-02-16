namespace GalaxyStorm.ViewModels.Common
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Data.Models;
    using GalaxyStorm.Common.Contracts;

    public class PublicShardViewModel : IMapFrom<Shard>, ICustomMapFor
    {
        public string Title { get; set; }

        public double BuildSpeed { get; set; }

        public string IsLocked { get; set; }

        public int InhabitedPlanets { get { return this.Planets.Count(x => x.IsPopulated); } }

        public int TotalPlanets { get { return this.Planets.Count; } }

        public ICollection<PlayerPlanetViewModel> Planets { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Shard, PublicShardViewModel>()
                .ForMember(x => x.IsLocked, opts => opts.MapFrom(o => o.IsLocked ? "Locked" : "Open"));
        }
    }
}
