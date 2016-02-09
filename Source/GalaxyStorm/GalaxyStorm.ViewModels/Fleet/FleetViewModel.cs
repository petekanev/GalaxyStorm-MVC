namespace GalaxyStorm.ViewModels.Fleet
{
    using System;

    public class FleetViewModel
    {
        public FleetViewModel()
        {
        }

        public FleetViewModel(int barracksLevel)
        {
        }

        public UnitViewModel Scout { get; set; }

        public UnitViewModel Carrier { get; set; }

        public UnitViewModel Fighter { get; set; }

        public UnitViewModel Interceptor { get; set; }

        public UnitViewModel Bomber { get; set; }

        public UnitViewModel Juggernaut { get; set; }

        public int BarracksLevel { get; set; }
    }
}
