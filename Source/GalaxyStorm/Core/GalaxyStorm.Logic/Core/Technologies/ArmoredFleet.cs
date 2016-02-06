namespace GalaxyStorm.Logic.Core.Technologies
{
    using System;

    public class ArmoredFleet : ITechnology
    {
        private const double EnergyCoeff = 10.2;
        private const double CrystalCoeff = 12.4;
        private const double MetalCoeff = 20;
        private const double ResearchTimeCoeff = 1;

        public string Name
        {
            get { return "Armored Fleet"; }
        }

        public string Description { get { return "The ships you build are more resilient in battle"; }}

        public int MaxLevel
        {
            get { return 3; }
        }

        public double[] Modifier
        {
            get { return new[] { 0, 0.1, 0.15, 0.3, 0 }; }
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
                    TimeSpan.FromMinutes(88*ResearchTimeCoeff),
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
