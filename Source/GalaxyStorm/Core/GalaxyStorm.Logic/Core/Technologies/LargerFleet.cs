namespace GalaxyStorm.Logic.Core.Technologies
{
    using System;

    public class LargerFleet : ITechnology
    {
        private const double EnergyCoeff = 19.2;
        private const double CrystalCoeff = 14.4;
        private const double MetalCoeff = 15;
        private const double ResearchTimeCoeff = 1;

        public string Name { get { return "Larger Fleet"; } }

        public string Description
        {
            get { return "Increase fleet size when attacking."; }
        }

        public int MaxLevel
        {
            get { return 5; }
        }

        public double[] Modifier
        {
            get { return new[] { 50.0, 100.0, 250.0, 400.0, 750.0, 1500.0, 0 }; }
        }

        public int Prerequisite
        {
            get { return 4; }
        }

        public TimeSpan[] ResearchTime
        {
            get
            {
                return new[]
                {
                    TimeSpan.FromMinutes(0),
                    TimeSpan.FromMinutes(59*ResearchTimeCoeff),
                    TimeSpan.FromMinutes(88*ResearchTimeCoeff),
                    TimeSpan.FromMinutes(120*ResearchTimeCoeff),
                    TimeSpan.FromMinutes(166*ResearchTimeCoeff),
                    TimeSpan.FromMinutes(201*ResearchTimeCoeff),
                    TimeSpan.FromMinutes(0)
                };
            }
        }

        public int[] GetRequiredResources(int level)
        {
            if (level <= 0 || level > this.MaxLevel)
            {
                return new[] { 0, 0, 0 };
            }

            return new[]
            {
                (int) (100 * EnergyCoeff) * level,
                (int) (100 * CrystalCoeff) * level,
                (int) (100 * MetalCoeff) * level
            };
        }
    }
}
