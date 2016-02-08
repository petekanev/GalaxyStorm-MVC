namespace GalaxyStorm.ViewModels.Buildings
{
    using System;
    using Data.Models.PlayerObjects;

    public class BuildingsViewModel
    {
        public BuildingsViewModel()
        {
        }

        public BuildingsViewModel(Buildings model)
        {
            this.CurrentlyBuilding = model.CurrentlyBuilding.ToString();
            this.EndTime = model.EndTime;
            this.StartTime = model.StartTime;

            if (model.EndTime.HasValue)
            {
                var mins = model.EndTime.Value - DateTime.Now;
                this.MinutesLeftToBuild = mins.TotalMinutes;

                var totalTime = model.EndTime.Value - model.StartTime.Value;
                var totalSegments = totalTime.TotalMinutes / 100;

                var percents = 100 - (this.MinutesLeftToBuild / totalSegments);
                this.PercentsBuilt = percents;
            }
        }

        public BuildingViewModel Headquarters { get; set; }

        public BuildingViewModel ResearchCentre { get; set; }

        public BuildingViewModel Barracks { get; set; }

        public ResourceBuildingViewModel SolarCollector { get; set; }

        public ResourceBuildingViewModel CrystalExtractor { get; set; }

        public ResourceBuildingViewModel MetalScrapper { get; set; }

        public double MinutesLeftToBuild { get; set; }

        public double PercentsBuilt { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public string CurrentlyBuilding { get; set; }
    }
}
