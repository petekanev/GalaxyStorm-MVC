namespace GalaxyStorm.ViewModels.Technologies
{
    using System;
    using AutoMapper;
    using Data.Models.PlayerObjects;
    using GalaxyStorm.Common.Contracts;
    using Logic.Core.Technologies;

    public class MoreResourcesViewModel : AbstractTechnologyViewModel, IMapFrom<MoreResources>, IMapFrom<Technologies>, ICustomMapFor
    {
        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Technologies, MoreResourcesViewModel>()
                .ForMember(x => x.Level, opts => opts.MapFrom(y => y.MoreResourcesLevel));

            config.CreateMap<MoreResources, MoreResourcesViewModel>()
                .ForAllMembers(x => x.Ignore());
            config.CreateMap<MoreResources, MoreResourcesViewModel>()
                .ForMember(x => x.Description, opts => opts.MapFrom(y => y.Description))
                .ForMember(x => x.Name, opts => opts.MapFrom(y => y.Name))
                .ForMember(x => x.Prerequisite, opts => opts.MapFrom(y => y.Prerequisite))
                .ForMember(x => x.MaxLevel, opts => opts.MapFrom(y => y.MaxLevel))
                .ForMember(x => x.Modifier, opts => opts.MapFrom(y => y.Modifier[this.Level]))
                .ForMember(x => x.NextModifier, opts => opts.MapFrom(y => y.Modifier[this.Level + 1]))
                .ForMember(x => x.RequiredEnergy, opts => opts.MapFrom(y => y.GetRequiredResources(this.Level + 1)[0]))
                .ForMember(x => x.RequiredCrystals, opts => opts.MapFrom(y => y.GetRequiredResources(this.Level + 1)[1]))
                .ForMember(x => x.RequiredMetal, opts => opts.MapFrom(y => y.GetRequiredResources(this.Level + 1)[2]))
                .ForMember(x => x.RequiredResearchTime, opts => opts.MapFrom(y => y.ResearchTime[this.Level + 1].TotalMinutes));
        }
    }
}