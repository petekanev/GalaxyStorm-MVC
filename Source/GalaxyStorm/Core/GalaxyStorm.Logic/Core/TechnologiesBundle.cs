namespace GalaxyStorm.Logic.Core
{
    using Technologies;

    public class TechnologiesBundle
    {
        public TechnologiesBundle()
        {
            ArmoredFleet = new ArmoredFleet();
            CheaperFleet = new CheaperFleet();
            FasterConstruction = new FasterConstruction();
            LargerFleet = new LargerFleet();
            MoreResources = new MoreResources();
        }

        public ArmoredFleet ArmoredFleet { get; set; }

        public CheaperFleet CheaperFleet { get; set; }

        public FasterConstruction FasterConstruction { get; set; }

        public LargerFleet LargerFleet { get; set; }

        public MoreResources MoreResources { get; set; }
    }
}
