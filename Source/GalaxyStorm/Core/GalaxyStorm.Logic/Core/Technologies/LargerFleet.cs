namespace GalaxyStorm.Logic.Core.Technologies
{
    using System;

    public class LargerFleet : ITechnology
    {
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
            get { return new[] { 100.0, 150.0, 350.0, 500.0, 1500.0 }; }
        }

        public int Prerequisite
        {
            get { return 3; }
        }

        public TimeSpan[] ResearchTime { get; private set; }
        
        public int[] GetRequiredResources(int level)
        {
            throw new NotImplementedException();
        }
    }
}
