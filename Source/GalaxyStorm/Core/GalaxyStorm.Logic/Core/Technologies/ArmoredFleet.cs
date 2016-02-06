namespace GalaxyStorm.Logic.Core.Technologies
{
    using System;

    public class ArmoredFleet : ITechnology
    {
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
            get { return new[] { 0, 0.1, 0.15, 0.3 }; }
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
