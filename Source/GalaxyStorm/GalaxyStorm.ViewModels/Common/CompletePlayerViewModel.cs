namespace GalaxyStorm.ViewModels.Common
{
    using System;
    using Data.Models.PlayerObjects;

    public class CompletePlayerViewModel
    {
        public long Energy { get; set; }

        public long Crystal { get; set; }

        public long Metal { get; set; }

        public long EnergyPerHour { get; set; }

        public long CrystalPerHour { get; set; }

        public long MetalPerHour { get; set; }

        public int HeadquartersLevel { get; set; }

        public int BarracksLevel { get; set; }

        public int ResearchCentreLevel { get; set; }

        public int SolarCollectorLevel { get; set; }

        public int CrystalExtractorLevel { get; set; }

        public int MetalScrapperLevel { get; set; }

        public double MinutesToBuild { get; set; }

        public string CurrentlyBuilding { get; set; }
    }
}
