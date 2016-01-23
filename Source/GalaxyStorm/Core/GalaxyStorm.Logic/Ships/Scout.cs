namespace GalaxyStorm.Logic.Ships
{
    using System;

    public class Scout : IShip
    {
        private const double AtkCoeff = 1;
        private const double ArmorCoeff = 1;
        private const double CargoCoeff = 10;

        public string Name
        {
            get { return "Scout"; }
        }

        public string Description
        {
            get { return "Tiny fragile ship. The ship is ideal for recon and spying."; }
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
            get { return 1; }
        }

        public TimeSpan BuildTime { get; private set; }

        public int[] RequiredResourcesToBuild { get; private set; }
    }
}
