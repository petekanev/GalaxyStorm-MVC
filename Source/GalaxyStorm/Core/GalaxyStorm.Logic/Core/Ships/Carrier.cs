namespace GalaxyStorm.Logic.Core.Ships
{
    using System;

    public class Carrier : IShip
    {
        private const double AtkCoeff = 0;
        private const double ArmorCoeff = 2.5;
        private const double CargoCoeff = 150;

        public string Name
        {
            get { return "Carrier"; }
        }

        public string Description
        {
            get { return "Big armored ship. Perfect for transporting large amounts of resources."; }
        }

        public int Attack
        {
            get { return (int)(10 * AtkCoeff);}
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
            get { return 1; }
        }

        public TimeSpan BuildTime { get; private set; }
        
        public int[] RequiredResourcesToBuild { get; private set; }
    }
}
