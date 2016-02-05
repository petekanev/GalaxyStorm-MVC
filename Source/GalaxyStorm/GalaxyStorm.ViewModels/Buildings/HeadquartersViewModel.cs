namespace GalaxyStorm.ViewModels.Buildings
{
    using System;

    public class HeadquartersViewModel
    {
        public int HeadquartersLevel { get; set; }

        public int MaxLevel { get; set; }

        public int RequiredEnergy { get; set; }

        public int RequiredCrystals { get; set; }

        public int RequiredMetal { get; set; }

        public double RequiredBuildTime { get; set; }

        public int Prerequisites { get; set; }
    }
}
