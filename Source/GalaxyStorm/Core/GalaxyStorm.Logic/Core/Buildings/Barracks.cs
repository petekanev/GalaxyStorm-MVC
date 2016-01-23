namespace GalaxyStorm.Logic.Core.Buildings
{
    using System;

    public class Barracks : IBuilding
    {
        private const double BuildTimeCoeff = 1;
        private const double EnergyCoeff = 1.75;
        private const double CrystalCoeff = 2.45;
        private const double MetalCoeff = 2;

        public string Name
        {
            get { return "Barracks"; }
        }

        public string Description { get; private set; }

        public int MaxLevel
        {
            get { return 5; }
        }

        public int Prerequisite
        {
            get { return 2; }
        }

        public TimeSpan[] BuildTime
        {
            get
            {
                return new[]
                {
                    TimeSpan.FromMinutes(7*BuildTimeCoeff),
                    TimeSpan.FromMinutes(19.4*BuildTimeCoeff),
                    TimeSpan.FromMinutes(42*BuildTimeCoeff),
                    TimeSpan.FromMinutes(83*BuildTimeCoeff),
                    TimeSpan.FromMinutes(172*BuildTimeCoeff)
                };
            }
        }

        public int[] GetRequiredResources(int level)
        {
            if (level <= 0 || level > this.MaxLevel)
            {
                throw new ArgumentOutOfRangeException("level", "Building level should be within the 1 and MaxLevel constant constraints!");
            }

            return new[]
            {
                (int) ((100 * EnergyCoeff) * (level * 0.75)),
                (int) ((100 * CrystalCoeff) * (level * 0.75)),
                (int) ((100 * MetalCoeff) * (level * 0.75))
            };
        }
    }
}
