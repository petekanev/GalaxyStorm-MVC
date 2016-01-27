namespace GalaxyStorm.Logic.Core
{
    using System;
    using Buildings;

    public class BuildingsBundle
    {
        public BuildingsBundle()
        {
            this.Headquarters = new Headquarters();
            this.SolarCollector = new SolarCollector();
            this.CrystalExtractor = new CrystalExtractor();
            this.MetalScrapper = new MetalScrapper();
            this.Barracks = new Barracks();
            this.ResearchCentre = new ResearchCentre();
        }

        public Headquarters Headquarters { get; set; }

        public SolarCollector SolarCollector { get; set; }

        public CrystalExtractor CrystalExtractor { get; set; }

        public MetalScrapper MetalScrapper { get; set; }

        public Barracks Barracks { get; set; }

        public ResearchCentre ResearchCentre { get; set; }
    }
}
