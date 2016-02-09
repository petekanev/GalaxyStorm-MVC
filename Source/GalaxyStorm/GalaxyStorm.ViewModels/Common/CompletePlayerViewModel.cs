namespace GalaxyStorm.ViewModels.Common
{
    using Buildings;
    using Fleet;
    using Technologies;

    public class CompletePlayerViewModel
    {
        public CompletePlayerViewModel()
        {
        }

        public ResourcesViewModel Resources { get; set; }

        public BuildingsViewModel Buildings { get; set; }

        public TechnologiesViewModel Technologies { get; set; }

        public PlanetViewModel Planet { get; set; }

        public FleetViewModel Fleet { get; set; }
    }
}
