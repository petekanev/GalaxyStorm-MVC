namespace GalaxyStorm.ViewModels.Fleet
{
    using Logic.Core.Ships;

    public class UnitViewModel
    {
        public UnitViewModel()
        {
        }

        public UnitViewModel(int onPlanet, int dispatched, string shipName)
        {
            this.Name = shipName;

            this.AmountDispatched = dispatched;
            this.AmountOnPlanet = onPlanet;
        }

        public UnitViewModel(int onPlanet, int dispatched, IShip ship, double cheaperFleetModifier = 0)
            : this(ship, cheaperFleetModifier)
        {
            this.AmountDispatched = dispatched;
            this.AmountOnPlanet = onPlanet;
        }

        public UnitViewModel(IShip ship, double cheaperFleetModifier = 0)
        {
            this.Name = ship.Name;
            this.Description = ship.Description;
            this.Attack = ship.Attack;
            this.Armor = ship.Armor;
            this.BuildTime = ship.BuildTime.TotalMinutes;
            this.CargoCapacity = ship.CargoCapacity;
            this.Prerequisite = ship.Prerequisite;
            this.PointsOnRecruit = ship.PointsOnRecruit;
            this.PointsOnKill = ship.PointsOnKill;

            var requiredResources = ship.RequiredResourcesToBuild;
            this.RequiredEnergy = requiredResources[0] - (int)(cheaperFleetModifier * requiredResources[0]);
            this.RequiredCrystals = requiredResources[1] - (int)(cheaperFleetModifier * requiredResources[1]);
            this.RequiredMetal = requiredResources[2] - (int)(cheaperFleetModifier * requiredResources[2]);
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Attack { get; set; }

        public int Armor { get; set; }

        public int CargoCapacity { get; set; }

        public int Prerequisite { get; set; }

        public double BuildTime { get; set; }

        public int RequiredEnergy { get; set; }

        public int RequiredCrystals { get; set; }

        public int RequiredMetal { get; set; }

        public int AmountOnPlanet { get; set; }

        public int AmountDispatched { get; set; }

        public int PointsOnRecruit { get; set; }

        public int PointsOnKill { get; set; }
    }
}
