namespace GalaxyStorm.ViewModels.Common
{
    using Data.Models.PlayerObjects;
    using GalaxyStorm.Common.Contracts;

    public class SimpleResourcesViewModel : IMapFrom<Resources>
    {
        public long Energy { get; set; }

        public long Crystal { get; set; }

        public long Metal { get; set; }
    }
}
