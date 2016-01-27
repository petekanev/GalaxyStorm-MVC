namespace GalaxyStorm.Data.Models.PlayerObjects
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using BuildingsComplexTypes;

    public class Buildings
    {
        [Key]
        public int Id { get; set; }

        public HeadQuarters HeadQuarters { get; set; }

        public Barracks Barracks { get; set; }

        public ResearchCentre ResearchCentre { get; set; }

        public SolarCollector SolarCollector { get; set; }

        public CrystalExtractor CrystalExtractor { get; set; }

        public MetalScrapper MetalScrapper { get; set; }
    }
}
