namespace GalaxyStorm.Logic.Core.Buildings
{
    using System;

    public class ResearchCentre : IBuilding
    {
        private const double BuildTimeCoeff = 1;
        private const double EnergyCoeff = 2.05;
        private const double CrystalCoeff = 3.33;
        private const double MetalCoeff = 2.15;

        public string Name
        {
            get { return "Research Centre"; }
        }

        public string Description { get; private set; }

        public int MaxLevel
        {
            get { return 5; }
        }

        public int Prerequisite
        {
            get { return 5; }
        }

        public TimeSpan[] BuildTime
        {
            get
            {
                return new[]
                {
                    TimeSpan.FromMinutes(26*BuildTimeCoeff),
                    TimeSpan.FromMinutes(43*BuildTimeCoeff),
                    TimeSpan.FromMinutes(59*BuildTimeCoeff),
                    TimeSpan.FromMinutes(88*BuildTimeCoeff),
                    TimeSpan.FromMinutes(166*BuildTimeCoeff),
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
                (int) ((100 * EnergyCoeff) * (level * 0.9)),
                (int) ((100 * CrystalCoeff) * (level * 0.9)),
                (int) ((100 * MetalCoeff) * (level * 0.9))
            };
        }
    }
}
