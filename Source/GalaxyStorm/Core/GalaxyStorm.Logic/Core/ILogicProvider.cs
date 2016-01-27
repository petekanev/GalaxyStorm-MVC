namespace GalaxyStorm.Logic.Core
{
    public interface ILogicProvider
    {
        BuildingsBundle Buildings { get; set; }

        ShipsBundle Ships { get; set; }

        TechnologiesBundle Technologies { get; set; }
    }
}
