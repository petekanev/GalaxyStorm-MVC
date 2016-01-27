namespace GalaxyStorm.Data.Models.PlayerObjects.BuildingsComplexTypes
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [ComplexType]
    public class HeadQuarters
    {
        public int Level { get; set; }

        public bool IsBuilding { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }
    }
}
