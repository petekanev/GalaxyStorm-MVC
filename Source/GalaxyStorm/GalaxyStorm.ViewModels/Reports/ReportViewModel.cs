namespace GalaxyStorm.ViewModels.Reports
{
    using System;
    using AutoMapper;
    using Data.Models.PlayerObjects;
    using GalaxyStorm.Common.Contracts;

    public class ReportViewModel : IMapFrom<Report>, ICustomMapFor
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime ReceivedOn { get; set; }

        public bool IsRead { get; set; }

        public string Type { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<Report, ReportViewModel>()
                .ForMember(x => x.Type, opts => opts.MapFrom(y => y.Type.ToString()));
        }
    }
}
