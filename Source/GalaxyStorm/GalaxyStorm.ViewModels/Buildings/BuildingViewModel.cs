namespace GalaxyStorm.ViewModels.Buildings
{
    using System;
    using Logic.Core.Buildings;

    public class BuildingViewModel
    {
        public BuildingViewModel()
        {
        }

        public BuildingViewModel(int level, IBuilding res)
        {
            this.Level = level;
            this.Name = res.Name;
            this.Description = res.Description;
            this.MaxLevel = res.MaxLevel;
            this.Prerequisite = res.Prerequisite;
            this.RequiredBuildTime = this.Level < this.MaxLevel ? res.BuildTime[this.Level + 1].TotalMinutes : 0;

            var requiredResources = res.GetRequiredResources(this.Level + 1);
            this.RequiredEnergy = requiredResources[0];
            this.RequiredCrystals = requiredResources[1];
            this.RequiredMetal = requiredResources[2];
        }

        public int Level { get; set; }

        public int MaxLevel { get; set; }

        public int RequiredEnergy { get; set; }

        public int RequiredCrystals { get; set; }

        public int RequiredMetal { get; set; }

        public double RequiredBuildTime { get; set; }

        public int Prerequisite { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
