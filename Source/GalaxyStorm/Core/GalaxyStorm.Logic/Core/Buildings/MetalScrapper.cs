namespace GalaxyStorm.Logic.Core.Buildings
{
    using System;

    public class MetalScrapper : ResourceBuilding
    {
        private const double EnergyCoeff = 4;
        private const double CrystalCoeff = 3.4;
        private const double MetalCoeff = 3;

        public override string Name
        {
            get { return "Metal Scrapper"; }
        }

        public override string Description
        {
            get { return "Retrieves metal from floating space debris"; }
        }

        public override int[] GetRequiredResources(int level)
        {

            if (level <= 0 || level > this.MaxLevel)
            {
                return new[] { 0, 0, 0 };
            }

            return new[]
            {
                (int) (100 * EnergyCoeff) * level,
                (int) (100 * CrystalCoeff) * level,
                (int) (100 * MetalCoeff) * level
            };
        }
    }
}
