namespace GalaxyStorm.ViewModels.Shards
{
    using System;
    using Data.Models;
    using GalaxyStorm.Common.Contracts;

    public class SimpleShardViewModel : IMapFrom<Shard>
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
