namespace GalaxyStorm.ViewModels.Technologies
{
    using Logic.Core.Technologies;

    public class TechnologyViewModel
    {
        public TechnologyViewModel()
        {
        }

        public TechnologyViewModel(int level, ITechnology res)
        {
            this.Level = level;
            this.Name = res.Name;
            this.Description = res.Description;
            this.MaxLevel = res.MaxLevel;
            this.Prerequisite = res.Prerequisite;
            this.RequiredResearchTime = this.Level < this.MaxLevel ? res.ResearchTime[this.Level + 1].TotalMinutes : 0;

            this.Modifiers = res.Modifier;

            var requiredResources = res.GetRequiredResources(this.Level + 1);
            this.RequiredEnergy = requiredResources[0];
            this.RequiredCrystals = requiredResources[1];
            this.RequiredMetal = requiredResources[2];
        }

        public int Level { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double[] Modifiers { get; set; }

        public int MaxLevel { get; set; }

        public int Prerequisite { get; set; }

        public int RequiredEnergy { get; set; }

        public int RequiredCrystals { get; set; }

        public int RequiredMetal { get; set; }

        public double RequiredResearchTime { get; set; }
    }
}
