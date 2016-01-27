namespace GalaxyStorm.Logic.Core
{
    using System;

    /// <summary>
    /// Contains all the necessary bundles
    /// </summary>
    public class LogicProvider : ILogicProvider
    {
        public LogicProvider(BuildingsBundle buildings, ShipsBundle ships, TechnologiesBundle tech)
        {
            this.Buildings = buildings;

            this.Ships = ships;

            this.Technologies = tech;
        }

        public LogicProvider()
        {
            this.Buildings = new BuildingsBundle();

            this.Ships = new ShipsBundle();

            this.Technologies = new TechnologiesBundle();
        }

        public BuildingsBundle Buildings { get; set; }

        public ShipsBundle Ships { get; set; }

        public TechnologiesBundle Technologies { get; set; }
    }
}
