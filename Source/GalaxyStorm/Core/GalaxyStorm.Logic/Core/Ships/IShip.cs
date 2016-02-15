namespace GalaxyStorm.Logic.Core.Ships
{
    using System;

    public interface IShip
    {
        string Name { get; }

        string Description { get; }

        int Attack { get; }

        int Armor { get; }

        int CargoCapacity { get; }

        /// <summary>
        /// Required Barracks level in order to build the ship
        /// </summary>
        int Prerequisite { get; }

        /// <summary>
        /// The time required to build a single ship
        /// </summary>
        TimeSpan BuildTime { get; }

        /// <summary>
        /// Required resources in the following order: energy -> crystal -> metal => [e, c, m]
        /// </summary>
        int[] RequiredResourcesToBuild { get; }

        int PointsOnRecruit { get; }

        int PointsOnKill { get; }
    }
}
