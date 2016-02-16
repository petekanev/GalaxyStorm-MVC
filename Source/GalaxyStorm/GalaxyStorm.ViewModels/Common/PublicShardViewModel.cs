namespace GalaxyStorm.ViewModels.Common
{
    using System.Collections.Generic;
    using Data.Models;
    using GalaxyStorm.Common.Contracts;

    public class PublicShardViewModel : IMapFrom<Shard>
    {
        public string Title { get; set; }

        public ICollection<PublicPlanetViewModel> Planets { get; set; }
    }
}
