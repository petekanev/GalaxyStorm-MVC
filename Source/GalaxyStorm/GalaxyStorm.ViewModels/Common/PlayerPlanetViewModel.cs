namespace GalaxyStorm.ViewModels.Common
{
    using System;
    using Data.Models;
    using GalaxyStorm.Common.Contracts;

    public class PlayerPlanetViewModel : IMapFrom<Planet>
    {
        public int X { get; set; }

        public int Y { get; set; }

        public string Title { get; set; }

        public bool IsPopulated { get; set; }
    }
}
