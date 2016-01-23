namespace GalaxyStorm.Logic.Core.Technologies
{
    using System;

    public class MoreResources : ITechnology
    {
        public string Name
        {
            get { return "Bountiful Mines"; }
        }
        
        public string Description { get; private set; }

        public int MaxLevel
        {
            get { return 3; }
        }

        public double[] Modifier
        {
            get { return new[] { 0.25, 0.50, 1 }; }
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
