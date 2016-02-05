namespace GalaxyStorm.ViewModels.Buildings
{
    using System;

    public class BuildingsViewModel
    {
        public HeadquartersViewModel Headquarters { get; set; }

        public int BarracksLevel { get; set; }

        public int ResearchCentreLevel { get; set; }

        public int SolarCollectorLevel { get; set; }

        public int CrystalExtractorLevel { get; set; }

        public int MetalScrapperLevel { get; set; }

        public double MinutesLeftToBuild { get; set; }

        public double PercentsBuilt { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public string CurrentlyBuilding { get; set; }

    }
}
