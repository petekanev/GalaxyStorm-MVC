namespace GalaxyStorm.Logic.Core.Ships
{
    using System;

    public class Juggernaut : IShip
    {
        private const double AtkCoeff = 100;
        private const double ArmorCoeff = 40;
        private const double CargoCoeff = 200;

        private const double EnergyCoeff = 16;
        private const double CrystalCoeff = 22;
        private const double MetalCoeff = 19.5;

        private const int RecruitPoints = 50;
        private const int KillPoints = 120;

        private const double BuildTimeMinutes = 30;

        public string Name
        {
            get { return "Juggernaut"; }
        }

        public string Description
        {
            get { return "The ship of all ships. As the name suggests, this unit is almost unstoppable."; }
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
            get { return 5; }
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

        public int PointsOnRecruit
        {
            get { return RecruitPoints; }
        }

        public int PointsOnKill { get { return KillPoints; } }
    }
}
