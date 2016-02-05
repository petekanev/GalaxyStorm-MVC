namespace GalaxyStorm.ViewModels.Technologies
{
    using System;

    public abstract class AbstractTechnologyViewModel
    {
        public int Level { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Modifier { get; set; }

        public double NextModifier { get; set; }

        public int MaxLevel { get; set; }

        public int Prerequisite { get; set; }

        public int RequiredEnergy { get; set; }

        public int RequiredCrystals { get; set; }

        public int RequiredMetal { get; set; }

        public double RequiredResearchTime { get; set; }
    }
}
