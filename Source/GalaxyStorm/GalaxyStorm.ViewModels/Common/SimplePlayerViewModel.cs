namespace GalaxyStorm.ViewModels.Common
{
    using System;

    public class SimplePlayerViewModel
    {
        public int NumberOfReports { get; set; }

        public int PlanetPoints { get; set; }

        public int NeutralPoints { get; set; }

        public int CombatPoints { get; set; }

        public PlanetViewModel Planet { get; set; }

        public string CurrentlyBuilding { get; set; }

        public string CurrentlyResearching { get; set; }

        public string CurrentlyRecruiting { get; set; }
    }
}
