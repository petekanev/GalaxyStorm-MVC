namespace GalaxyStorm.Logic.Core.Ships
{
    using System;

    public class Bomber : IShip
    {
        private const double AtkCoeff = 25;
        private const double ArmorCoeff = 5;
        private const double CargoCoeff = 20;

        private const double EnergyCoeff = 2;
        private const double CrystalCoeff = 4.2;
        private const double MetalCoeff = 5;

        private const int RecruitPoints = 20;
        private const int KillPoints = 50;

        private const double BuildTimeMinutes = 12.5;

        public string Name
        {
            get { return "Bomber"; }
        }

        public string Description
        {
            get { return "Heavy combat ship. Penetrates even the hardest hull armor. Expensive."; }
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
            get { return 4; }
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
