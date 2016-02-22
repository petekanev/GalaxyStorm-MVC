namespace GalaxyStorm.ViewModels.Shards
{
    using System;
    using System.ComponentModel;
    using Data.Models;
    using GalaxyStorm.Common.Contracts;

    public class SimpleShardViewModel : IMapFrom<Shard>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [DisplayName("Is Locked?")]
        public bool IsLocked { get; set; }

        [DisplayName("Build Speed")]
        public double BuildSpeed { get; set; }
    }
}
