namespace GalaxyStorm.ViewModels.Buildings
{
    using System;
    using Logic.Core.Buildings;

    public class ResourceBuildingViewModel : BuildingViewModel
    {
        public ResourceBuildingViewModel()
            : base()
        {
        }

        public ResourceBuildingViewModel(int level, ResourceBuilding building)
            : base(level, building)
        {
            this.ResourceIncome = building.ResourceGeneration[level];
            this.NextResourceIncome = building.ResourceGeneration[level + 1];
        }

        public long ResourceIncome { get; set; }

        public long NextResourceIncome { get; set; }
    }
}
