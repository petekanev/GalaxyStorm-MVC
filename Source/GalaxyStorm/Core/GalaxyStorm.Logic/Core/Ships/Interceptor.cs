namespace GalaxyStorm.Logic.Core.Ships
{
    using System;

    public class Interceptor : IShip
    {
        private const double AtkCoeff = 13;
        private const double ArmorCoeff = 3;
        private const double CargoCoeff = 12;

        private const double EnergyCoeff = 1.45;
        private const double CrystalCoeff = 1;
        private const double MetalCoeff = 2;

        private const double BuildTimeMinutes = 8;

        public string Name
        {
            get { return "Interceptor"; }
        }

        public string Description
        {
            get { return "Middle-class combat ship, intercepts small groups of ships effortlessly."; }
        }

        public int Attack
        {
            get { return (int)(10 * AtkCoeff); }
        }

        public int Armor
        {
            get { return (int)(10 * ArmorCoeff); }
        }

        public int CargoCapacity
        {
            get { return (int)(10 * CargoCoeff); }
        }

        public int Prerequisite
        {
            get { return 3; }
        }

        public TimeSpan BuildTime
        {
            get
            {
                return TimeSpan.FromMinutes(BuildTimeMinutes);
            }
        }

        public int[] RequiredResourcesToBuild
        {
            get
            {
                return new[]
                {
                    (int)(100 * EnergyCoeff), 
                    (int)(100 * CrystalCoeff), 
                    (int)(100 * MetalCoeff)
                };
            }
        }
    }
}
