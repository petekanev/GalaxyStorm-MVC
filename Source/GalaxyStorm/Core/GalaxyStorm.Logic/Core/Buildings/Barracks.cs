namespace GalaxyStorm.Logic.Core.Buildings
{
    using System;

    public class Barracks : IBuilding
    {
        private const double BuildTimeCoeff = 1;
        private const double EnergyCoeff = 9.75;
        private const double CrystalCoeff = 10.45;
        private const double MetalCoeff = 11;

        public string Name
        {
            get { return "Barracks"; }
        }

        public string Description {
            get
            {
                return
                    "Maecenas volutpat mi tellus, non pellentesque nunc maximus sed. Fusce sed rutrum magna. Nullam vestibulum libero vel iaculis consectetur. Sed ut congue metus. Praesent cursus tortor in mi feugiat, et interdum augue congue. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse potenti. Morbi et ex rutrum, egestas est in, sagittis dui. Maecenas eu nunc ac eros eleifend iaculis.";
            }
        }

        public int MaxLevel
        {
            get { return 5; }
        }

        public int Prerequisite
        {
            get { return 2; }
        }

        public TimeSpan[] BuildTime
        {
            get
            {
                return new[]
                {
                    TimeSpan.FromMinutes(0),
                    TimeSpan.FromMinutes(7*BuildTimeCoeff),
                    TimeSpan.FromMinutes(19.4*BuildTimeCoeff),
                    TimeSpan.FromMinutes(42*BuildTimeCoeff),
                    TimeSpan.FromMinutes(83*BuildTimeCoeff),
                    TimeSpan.FromMinutes(172*BuildTimeCoeff),
                    TimeSpan.FromMinutes(0),
                };
            }
        }

        public int[] GetRequiredResources(int level)
        {
            if (level <= 0 || level > this.MaxLevel)
            {
                return new[] { 0, 0, 0 };
            }

            return new[]
            {
                (int) ((100 * EnergyCoeff) * (level * 0.75)),
                (int) ((100 * CrystalCoeff) * (level * 0.75)),
                (int) ((100 * MetalCoeff) * (level * 0.75))
            };
        }
    }
}
