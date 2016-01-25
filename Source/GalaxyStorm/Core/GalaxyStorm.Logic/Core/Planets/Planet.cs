namespace GalaxyStorm.Logic.Core.Planets
{
    using System;

    public class Planet
    {
        public int X { get; set; }

        public int Y { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// A value from 1 to 0 that amplifies energy resource generation
        /// </summary>
        public double EnergyModifier { get; set; }

        /// <summary>
        /// A value from 1 to 0 that amplifies crystal resource generation
        /// </summary>
        public double CrystalModifier { get; set; }

        /// <summary>
        /// A value from 1 to 0 that amplifies metal resource generation
        /// </summary>
        public double MetalModifier { get; set; }

        /// <summary>
        /// Occupant
        /// </summary>
        public OccupiedBy OccupiedBy { get; set;}
    }
}
