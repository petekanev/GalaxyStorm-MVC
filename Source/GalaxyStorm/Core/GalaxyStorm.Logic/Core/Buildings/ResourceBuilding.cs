namespace GalaxyStorm.Logic.Core.Buildings
{
    using System;
    using System.Linq;

    public abstract class ResourceBuilding : IBuilding
    {
        private const double ResourceCoeff = 1;

        private const double BuildTimeCoeff = 1;

        public abstract string Name { get; }

        public abstract string Description { get; }

        public int MaxLevel
        {
            get { return 15; }
        }

        public int Prerequisite
        {
            get { return 1; }
        }

        public TimeSpan[] BuildTime
        {
            get
            {
                return new[] { 
                TimeSpan.FromMinutes(0), 
                TimeSpan.FromMinutes(0),
                TimeSpan.FromMinutes(2.5 * BuildTimeCoeff), 
                TimeSpan.FromMinutes(7 * BuildTimeCoeff), 
                TimeSpan.FromMinutes(14.3 * BuildTimeCoeff),
                TimeSpan.FromMinutes(19.8 * BuildTimeCoeff),
                TimeSpan.FromMinutes(28 * BuildTimeCoeff),
                TimeSpan.FromMinutes(32 * BuildTimeCoeff),
                TimeSpan.FromMinutes(42 * BuildTimeCoeff),
                TimeSpan.FromMinutes(50 * BuildTimeCoeff),
                TimeSpan.FromMinutes(60.1 * BuildTimeCoeff),
                TimeSpan.FromMinutes(72 * BuildTimeCoeff),
                TimeSpan.FromMinutes(92 * BuildTimeCoeff),
                TimeSpan.FromMinutes(100 * BuildTimeCoeff),
                TimeSpan.FromMinutes(110 * BuildTimeCoeff),
                TimeSpan.FromMinutes(120 * BuildTimeCoeff),
                TimeSpan.FromMinutes(0)
            };
            }
        }

        public int[] ResourceGeneration
        {
            get { return (new[] { 100, 150, 275, 350, 450, 550, 650, 720, 800, 940, 1100, 1200, 1400, 1800, 2250, 3000, 0 }).Select(x => (int)(x * ResourceCoeff)).ToArray(); }
        }

        public abstract int[] GetRequiredResources(int level);
    }
}
