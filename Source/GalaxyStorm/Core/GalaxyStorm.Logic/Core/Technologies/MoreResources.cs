namespace GalaxyStorm.Logic.Core.Technologies
{
    using System;

    public class MoreResources : ITechnology
    {
        private const double EnergyCoeff = 25;
        private const double CrystalCoeff = 28.4;
        private const double MetalCoeff = 23;
        private const double ResearchTimeCoeff = 1.25;

        public string Name
        {
            get { return "Bountiful Mines"; }
        }

        public string Description { get { return "You earn more energy, crystals, and metal per hour."; } }

        public int MaxLevel
        {
            get { return 3; }
        }

        public double[] Modifier
        {
            get { return new[] { 0, 0.25, 0.50, 1}; }
        }

        public int Prerequisite
        {
            get { return 3; }
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
