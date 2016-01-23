namespace GalaxyStorm.Logic.Buildings
{
    using System;

    public class Headquarters : IBuilding
    {
        private const double BuildTimeCoeff = 1;
        private const double EnergyCoeff = 3.2;
        private const double CrystalCoeff = 1.4;
        private const double MetalCoeff = 2.75;

        public string Name
        {
            get { return "Headquarters"; }
        }

        public string Description { get; private set; }

        public int MaxLevel
        {
            get { return 10; }
        }

        public int Prerequisite
        {
            get { return 0; }
        }

        public TimeSpan[] BuildTime
        {
            get
            {
                return new[]
                {
                    TimeSpan.FromMinutes(1),
                    TimeSpan.FromMinutes(8.3*BuildTimeCoeff),
                    TimeSpan.FromMinutes(26*BuildTimeCoeff),
                    TimeSpan.FromMinutes(43*BuildTimeCoeff),
                    TimeSpan.FromMinutes(59*BuildTimeCoeff),
                    TimeSpan.FromMinutes(72*BuildTimeCoeff),
                    TimeSpan.FromMinutes(121*BuildTimeCoeff),
                    TimeSpan.FromMinutes(215*BuildTimeCoeff),
                    TimeSpan.FromMinutes(305*BuildTimeCoeff),
                    TimeSpan.FromMinutes(465*BuildTimeCoeff)
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
