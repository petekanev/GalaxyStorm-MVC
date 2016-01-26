namespace GalaxyStorm.Logic.Core
{
    using System;
    using Buildings;

    public class BuildingsBundle
    {
        static BuildingsBundle()
        {
            Headquarters = new Headquarters();
            SolarCollector = new SolarCollector();
            CrystalExtractor = new CrystalExtractor();
            MetalScrapper = new MetalScrapper();
            Barracks = new Barracks();
            ResearchCentre = new ResearchCentre();
        }

        public static Headquarters Headquarters { get; set; }

        public static SolarCollector SolarCollector { get; set; }

        public static CrystalExtractor CrystalExtractor { get; set; }

        public static MetalScrapper MetalScrapper { get; set; }

        public static Barracks Barracks { get; set; }

        public static ResearchCentre ResearchCentre { get; set; }
    }
}
