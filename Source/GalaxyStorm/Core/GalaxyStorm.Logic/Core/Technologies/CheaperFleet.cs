namespace GalaxyStorm.Logic.Core.Technologies
{
    using System;

    public class CheaperFleet : ITechnology
    {
        private const double EnergyCoeff = 13.2;
        private const double CrystalCoeff = 15.4;
        private const double MetalCoeff = 16;
        private const double ResearchTimeCoeff = 1;

        public string Name
        {
            get { return "Cheaper Fleet"; }
        }

        public string Description
        {
            get { return "Build more ships with fewer resources."; }
        }

        public int MaxLevel
        {
            get { return 3; }
        }

        public double[] Modifier
        {
            get { return new[] { 0, 0.05, 0.1, 0.2, 0 }; }
        }

        public int Prerequisite
        {
            get { return 2; }
        }

        public TimeSpan[] ResearchTime
        {
            get
            {
                return new[]
                {
                    TimeSpan.FromMinutes(0),
                    TimeSpan.FromMinutes(59*ResearchTimeCoeff),
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
