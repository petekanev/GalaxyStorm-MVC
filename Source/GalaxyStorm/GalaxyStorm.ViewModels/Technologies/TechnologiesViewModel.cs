namespace GalaxyStorm.ViewModels.Technologies
{
    using System;

    public class TechnologiesViewModel
    {
        public ArmoredFleetViewModel ArmoredFleet { get; set; }

        public CheaperFleetViewModel CheaperFleet { get; set; }

        public LargerFleetViewModel LargerFleet { get; set; }

        public FasterConstructionViewModel FasterConstruction { get; set; }

        public MoreResourcesViewModel MoreResources { get; set; }

        public double MinutesLeftToResearch { get; set; }

        public double PercentsResearched { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public string CurrentlyResearching { get; set; }
    }
}
