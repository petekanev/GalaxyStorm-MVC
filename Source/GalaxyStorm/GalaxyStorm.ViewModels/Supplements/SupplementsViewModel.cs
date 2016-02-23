namespace GalaxyStorm.ViewModels.Supplements
{
    using AutoMapper;
    using Common;
    using Data.Models.PlayerObjects;
    using GalaxyStorm.Common.Contracts;

    public class SupplementsViewModel : IMapFrom<PlayerObject>, ICustomMapFor
    {
        public string Id { get; set; }

        public string PlayerDisplayName { get; set; }

        public long Energy { get; set; }

        public long Crystal { get; set; }

        public long Metal { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<PlayerObject, SupplementsViewModel>()
                .ForMember(x => x.PlayerDisplayName, opts => opts.MapFrom(x => x.ApplicationUser.DisplayName))
                .ForMember(x => x.Energy, opts => opts.MapFrom(x => x.Resources.Energy))
                .ForMember(x => x.Crystal, opts => opts.MapFrom(x => x.Resources.Crystal))
                .ForMember(x => x.Metal, opts => opts.MapFrom(x => x.Resources.Metal));
        }
    }
}
