namespace GalaxyStorm.Data.Models.PlayerObjects
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Technologies
    {
        [Key]
        public int Id { get; set; }

        public int ArmorFleetLevel { get; set; }

        public int FasterConstructionLevel { get; set; }

        public int CheaperFleetLevel { get; set; }

        public int LargerFleetLevel { get; set; }

        public int MoreResourcesLevel { get; set; }

        public CurrentlyResearching CurrentlyResearching { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }
    }

    public enum CurrentlyResearching
    {
        None = 0,
        ArmorFleet = 1,
        FasterConstruction = 2,
        CheaperFleet = 3,
        LargerFleet = 4,
        MoreResources = 5
    }
}
