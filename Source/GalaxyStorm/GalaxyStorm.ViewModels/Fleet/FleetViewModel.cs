namespace GalaxyStorm.ViewModels.Fleet
{
    using System;
    using Data.Models.PlayerObjects;

    public class FleetViewModel
    {
        public FleetViewModel()
        {
        }

        public FleetViewModel(Units model)
        {
            this.CurrentlyRecruiting = model.CurrentlyRecruiting.ToString();
            this.EndTime = model.EndTime;
            this.StartTime = model.StartTime;

            if (model.EndTime.HasValue)
            {
                var mins = model.EndTime.Value - DateTime.Now;
                this.MinutesLeftToRecruit = mins.TotalMinutes;

                var totalTime = model.EndTime.Value - model.StartTime.Value;
                var totalSegments = totalTime.TotalMinutes / 100;

                var percents = 100 - (this.MinutesLeftToRecruit / totalSegments);
                this.PercentsRecruited = percents;
            }
        }

        public FleetViewModel(int barracksLevel, Units model)
            : this(model)
        {
            this.BarracksLevel = barracksLevel;
        }

        public UnitViewModel Scout { get; set; }

        public UnitViewModel Carrier { get; set; }

        public UnitViewModel Fighter { get; set; }

        public UnitViewModel Interceptor { get; set; }

        public UnitViewModel Bomber { get; set; }

        public UnitViewModel Juggernaut { get; set; }

        public int BarracksLevel { get; set; }

        public double MinutesLeftToRecruit { get; set; }

        public double PercentsRecruited { get; set; }

        public string CurrentlyRecruiting { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public int AmountRecruiting { get; set; }
    }
}
