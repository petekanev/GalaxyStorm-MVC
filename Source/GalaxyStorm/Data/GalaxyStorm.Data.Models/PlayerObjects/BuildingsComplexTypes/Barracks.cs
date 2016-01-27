namespace GalaxyStorm.Data.Models.PlayerObjects.BuildingsComplexTypes
{
    using System;

    public class Barracks
    {
        public int Level { get; set; }

        public bool IsBuilding { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }
    }
}
