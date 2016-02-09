namespace GalaxyStorm.ViewModels.Technologies
{
    using System;
    using Data.Models.PlayerObjects;

    public class TechnologiesViewModel
    {
        public TechnologiesViewModel()
        {
        }

        public TechnologiesViewModel(Technologies model)
        {
            this.CurrentlyResearching = model.CurrentlyResearching.ToString();
            this.EndTime = model.EndTime;
            this.StartTime = model.StartTime;

            if (model.EndTime.HasValue)
            {
                var mins = model.EndTime.Value - DateTime.Now;
                this.MinutesLeftToResearch = mins.TotalMinutes;

                var totalTime = model.EndTime.Value - model.StartTime.Value;
                var totalSegments = totalTime.TotalMinutes / 100;

                var percents = 100 - (this.MinutesLeftToResearch / totalSegments);
                this.PercentsResearched = percents;
            }
        }

        public TechnologiesViewModel(int researchCentreLevel, Technologies model)
            : this(model)
        {
            this.ResearchCentreLevel = researchCentreLevel;
        }

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

        public int ResearchCentreLevel { get; set; }
    }
}
