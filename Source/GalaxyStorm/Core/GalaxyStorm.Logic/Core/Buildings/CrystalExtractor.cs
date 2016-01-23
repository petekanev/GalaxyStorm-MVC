namespace GalaxyStorm.Logic.Core.Buildings
{
    using System;

    public class CrystalExtractor : ResourceBuilding
    {
        private const double EnergyCoeff = 1.4;
        private const double CrystalCoeff = 1;
        private const double MetalCoeff = 2;

        public override string Name
        {
            get { return "Crystal Extractor"; }
        }

        public override string Description
        {
            get { throw new NotImplementedException(); }
        }

        public override int[] GetRequiredResources(int level)
        {
            if (level <= 0 || level > base.MaxLevel)
            {
                throw new ArgumentOutOfRangeException("level", "Building level should be within the 1 and MaxLevel constant constraints!");
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
