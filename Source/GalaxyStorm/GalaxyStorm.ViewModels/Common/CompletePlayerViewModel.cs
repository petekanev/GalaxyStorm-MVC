namespace GalaxyStorm.ViewModels.Common
{
    using Buildings;
    using Technologies;

    public class CompletePlayerViewModel
    {
        public ResourcesViewModel Resources { get; set; }

        public BuildingsViewModel Buildings { get; set; }

        public TechnologiesViewModel Technologies { get; set; }

        public PlanetViewModel Planet { get; set; }
    }
}
