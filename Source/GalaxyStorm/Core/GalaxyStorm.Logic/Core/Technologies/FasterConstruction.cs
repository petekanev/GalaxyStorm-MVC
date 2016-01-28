namespace GalaxyStorm.Logic.Core.Technologies
{
    using System;

    public class FasterConstruction : ITechnology
    {
        public string Name
        {
            get { return "Nimble Workers"; }
        }

        public string Description { get; private set; }

        public int MaxLevel
        {
            get { return 3; }
        }

        public double[] Modifier
        {
            get
            {
                return new[] { 0, 0.1, 0.25, 0.33 };
            }
        }

        public int Prerequisite
        {
            get { return 1; }
        }

        // TODO:
        public TimeSpan[] ResearchTime { get; private set; }

        // TODO:
        public int[] GetRequiredResources(int level)
        {
            throw new NotImplementedException();
        }
    }
}
