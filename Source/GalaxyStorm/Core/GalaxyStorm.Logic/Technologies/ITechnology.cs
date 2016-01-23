namespace GalaxyStorm.Logic.Technologies
{
    using System;

    public interface ITechnology
    {
        string Name { get; }

        string Description { get; }

        int MaxLevel { get; }

        double[] Modifier { get; }

        /// <summary>
        /// Required Research Centre level in order to build
        /// </summary>
        int Prerequisite { get; }

        TimeSpan[] ResearchTime { get; }

        /// <summary>
        /// Required resources in the following order: energy -> crystal -> metal => [e, c, m]
        /// </summary>
        /// <param name="level"></param>
        /// <returns>the required [energy, crystal, metal]</returns>
        int[] GetRequiredResources(int level);
    }
}
