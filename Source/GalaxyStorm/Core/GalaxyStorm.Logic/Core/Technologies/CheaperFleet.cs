namespace GalaxyStorm.Logic.Core.Technologies
{
    using System;

    public class CheaperFleet : ITechnology
    {
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
            get { return new[] { 0.05, 0.1, 0.2 }; }
        }

        public int Prerequisite
        {
            get { return 2; }
        }

        public TimeSpan[] ResearchTime { get; private set; }
        
        public int[] GetRequiredResources(int level)
        {
            throw new NotImplementedException();
        }
    }
}
