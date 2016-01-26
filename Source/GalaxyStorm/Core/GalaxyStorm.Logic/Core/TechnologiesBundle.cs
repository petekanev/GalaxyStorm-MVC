namespace GalaxyStorm.Logic.Core
{
    using Technologies;

    public class TechnologiesBundle
    {
        static TechnologiesBundle()
        {
            ArmoredFleet = new ArmoredFleet();
            CheaperFleet = new CheaperFleet();
            FasterConstruction = new FasterConstruction();
            LargerFleet = new LargerFleet();
            MoreResources = new MoreResources();
        }

        public static ArmoredFleet ArmoredFleet { get; set; }

        public static CheaperFleet CheaperFleet { get; set; }

        public static FasterConstruction FasterConstruction { get; set; }

        public static LargerFleet LargerFleet { get; set; }

        public static MoreResources MoreResources { get; set; }
    }
}
