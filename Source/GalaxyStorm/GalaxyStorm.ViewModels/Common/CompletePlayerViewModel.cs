namespace GalaxyStorm.ViewModels.Common
{
    using Buildings;

    public class CompletePlayerViewModel
    {
        public ResourcesViewModel Resources { get; set; }

        public BuildingsViewModel Buildings { get; set; }

        public PlanetViewModel Planet { get; set; }
    }
}
