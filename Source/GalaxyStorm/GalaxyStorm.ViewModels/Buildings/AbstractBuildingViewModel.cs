namespace GalaxyStorm.ViewModels.Buildings
{
    using System;

    public abstract class AbstractBuildingViewModel
    {
        public int Level { get; set; }

        public int MaxLevel { get; set; }

        public int RequiredEnergy { get; set; }

        public int RequiredCrystals { get; set; }

        public int RequiredMetal { get; set; }

        public double RequiredBuildTime { get; set; }

        public int Prerequisites { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
