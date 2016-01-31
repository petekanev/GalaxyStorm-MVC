namespace GalaxyStorm.Data.Models.PlayerObjects
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Buildings
    {
        [Key]
        public int Id { get; set; }

        public int HeadQuartersLevel { get; set; }

        public int BarracksLevel { get; set; }

        public int ResearchCentreLevel { get; set; }

        public int SolarCollectorLevel { get; set; }

        public int CrystalExtractorLevel { get; set; }

        public int MetalScrapperLevel { get; set; }

        public CurrentlyBuilding CurrentlyBuilding { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }
    }

    public enum CurrentlyBuilding
    {
        None = 0,
        Headquarters = 1,
        Barracks = 2,
        ResearchCentre = 3,
        SolarCollector = 4,
        CrystalExtractor = 5,
        MetalScrapper = 6
    }
}
