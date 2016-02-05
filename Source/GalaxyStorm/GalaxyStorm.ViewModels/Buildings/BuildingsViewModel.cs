namespace GalaxyStorm.ViewModels.Buildings
{
    using System;

    public class BuildingsViewModel
    {
        public HeadquartersViewModel Headquarters { get; set; }

        public ResearchCentreViewModel ResearchCentre { get; set; }

        public BarracksViewModel Barracks { get; set; }

        public SolarCollectorViewModel SolarCollector { get; set; }

        public CrystalExtractorViewModel CrystalExtractor { get; set; }

        public MetalScrapperViewModel MetalScrapper { get; set; }

        public double MinutesLeftToBuild { get; set; }

        public double PercentsBuilt { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public string CurrentlyBuilding { get; set; }
    }
}
