namespace GalaxyStorm.Logic.Core.Technologies
{
    using System;

    public class FasterConstruction : ITechnology
    {
        private const double EnergyCoeff = 20.2;
        private const double CrystalCoeff = 14.4;
        private const double MetalCoeff = 14;
        private const double ResearchTimeCoeff = 1;

        public string Name
        {
            get { return "Nimble Workers"; }
        }

        public string Description { get { return "Buildings you upgrade are completed faster. Units you recruit become available sooner."; } }

        public int MaxLevel
        {
            get { return 3; }
        }

        public double[] Modifier
        {
            get
            {
                return new[] { 0, 0.1, 0.25, 0.33, 0 };
            }
        }

        public int Prerequisite
        {
            get { return 1; }
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
                    TimeSpan.FromMinutes(166*ResearchTimeCoeff),
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
