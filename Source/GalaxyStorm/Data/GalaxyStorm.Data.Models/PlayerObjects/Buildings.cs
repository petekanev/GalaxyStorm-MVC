namespace GalaxyStorm.Data.Models.PlayerObjects
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Buildings
    {
        [Key]
        public int Id { get; set; }

        public int HeadQuartersLevel { get; set; }

        public bool IsUpdatingHeadQuarters { get; set; }

        public int BarracksLevel { get; set; }

        public bool IsUpdatingBarracks { get; set; }

        public int ResearchCentreLevel { get; set; }

        public bool IsUpdatingResearchCentre { get; set; }

        public int SolarCollectorLevel { get; set; }

        public bool IsUpdatingSolarCollector { get; set; }

        public int CrystalExtractorLevel { get; set; }

        public bool IsUpdatingCrystalExtractor { get; set; }

        public int MetalScrapperLevel { get; set; }

        public bool IsUpdatingMetalScrapper { get; set; }
    }
}
