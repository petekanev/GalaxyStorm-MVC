namespace GalaxyStorm.ViewModels.Technologies
{
    using System;

    public class TechnologiesViewModel
    {
        public TechnologyViewModel ArmoredFleet { get; set; }

        public TechnologyViewModel CheaperFleet { get; set; }

        public TechnologyViewModel LargerFleet { get; set; }

        public TechnologyViewModel FasterConstruction { get; set; }

        public TechnologyViewModel MoreResources { get; set; }

        public double MinutesLeftToResearch { get; set; }

        public double PercentsResearched { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public string CurrentlyResearching { get; set; }
    }
}
