namespace GalaxyStorm.Logic.Core.Buildings
{
    using System;

    public interface IBuilding
    {
        string Name { get; }

        string Description { get; }

        int MaxLevel { get; }

        /// <summary>
        /// Required HQ levels in order to build
        /// </summary>
        int Prerequisite { get; }

        TimeSpan[] BuildTime { get; }

        /// <summary>
        /// Required resources in the following order: energy -> crystal -> metal => [e, c, m]
        /// </summary>
        /// <param name="level"></param>
        /// <returns>the required [energy, crystal, metal]</returns>
        int[] GetRequiredResources(int level);
    }
}
