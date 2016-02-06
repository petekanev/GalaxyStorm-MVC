namespace GalaxyStorm.ViewModels.Buildings
{
    using System;

    public class BuildingsViewModel
    {
        public BuildingViewModel Headquarters { get; set; }

        public BuildingViewModel ResearchCentre { get; set; }

        public BuildingViewModel Barracks { get; set; }

        public BuildingViewModel SolarCollector { get; set; }

        public BuildingViewModel CrystalExtractor { get; set; }

        public BuildingViewModel MetalScrapper { get; set; }

        public double MinutesLeftToBuild { get; set; }

        public double PercentsBuilt { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public string CurrentlyBuilding { get; set; }
    }
}
