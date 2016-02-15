namespace GalaxyStorm.Logic.Core.Ships
{
    using System;

    public class Scout : IShip
    {
        private const double AtkCoeff = 1;
        private const double ArmorCoeff = 1;
        private const double CargoCoeff = 10;

        private const double EnergyCoeff = 0.6;
        private const double CrystalCoeff = 1;
        private const double MetalCoeff = 0.75;

        private const int RecruitPoints = 5;
        private const int KillPoints = 5;

        private const double BuildTimeMinutes = 2.5;

        public string Name
        {
            get { return "Scout"; }
        }

        public string Description
        {
            get { return "Tiny fragile ship. The vessel is ideal for recon missions and spying. Not durable in combat."; }
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
