namespace GalaxyStorm.ViewModels.Info
{
    using AutoMapper;
    using Data.Models.PlayerObjects;
    using GalaxyStorm.Common.Contracts;

    public class InfoLeaderboardsViewModel : IMapFrom<PlayerObject>, ICustomMapFor
    {
        public string DisplayName { get; set; }

        public int PlanetPoints { get; set; }

        public int NeutralPoints { get; set; }

        public int CombatPoints { get; set; }

        public string ShardName { get; set; }

        public long TotalPoints { get { return this.PlanetPoints + this.NeutralPoints + this.CombatPoints; } }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<PlayerObject, InfoLeaderboardsViewModel>()
                .ForMember(i => i.DisplayName, opts => opts.MapFrom(x => x.ApplicationUser.DisplayName))
                .ForMember(i => i.ShardName, opts => opts.MapFrom(x => x.Planet.Shard.Title))
                .ForMember(i => i.PlanetPoints, opts => opts.MapFrom(x => x.Points.PointsPlanet))
                .ForMember(i => i.NeutralPoints, opts => opts.MapFrom(x => x.Points.PointsNeutral))
                .ForMember(i => i.CombatPoints, opts => opts.MapFrom(x => x.Points.PointsCombat));
        }
    }
}
