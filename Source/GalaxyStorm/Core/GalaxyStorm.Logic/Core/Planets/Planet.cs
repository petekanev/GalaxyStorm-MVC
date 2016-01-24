namespace GalaxyStorm.Logic.Core.Planets
{
    using System;

    public class Planet
    {
        public int X { get; set; }

        public int Y { get; set; }

        public string Name { get; set; }

        public double EnergyModifier { get; set; }

        public double CrystalModifier { get; set; }

        public double MetalModifier { get; set; }

        public OccupiedBy OccupiedBy { get; set;}
    }
}
