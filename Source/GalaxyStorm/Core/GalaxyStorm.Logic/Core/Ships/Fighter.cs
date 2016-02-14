namespace GalaxyStorm.Logic.Core.Ships
{
    using System;

    public class Fighter : IShip
    {
        private const double AtkCoeff = 7.5;
        private const double ArmorCoeff = 2.5;
        private const double CargoCoeff = 10;

        private const double EnergyCoeff = 0.75;
        private const double CrystalCoeff = 1;
        private const double MetalCoeff = 0.8;

        private const double BuildTimeMinutes = 4.5;

        public string Name
        {
            get { return "Fighter"; }
        }

        public string Description
        {
            get { return "Light combat ship. Lowest-class ship, ideal for taking down easy opponents."; }
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
            get { return 2; }
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
