namespace GalaxyStorm.ViewModels.Shards
{
    using System;
    using System.Collections.Generic;
    using Common;
    using Data.Models;
    using GalaxyStorm.Common.Contracts;

    public class ShardViewModel : IMapFrom<Shard>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsLocked { get; set; }

        public double BuildSpeed { get; set; }

        public IEnumerable<PlayerPlanetViewModel> Planets { get; set; }
    }
}
