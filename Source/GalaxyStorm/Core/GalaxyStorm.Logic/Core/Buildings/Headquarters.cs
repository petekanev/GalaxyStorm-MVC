namespace GalaxyStorm.Logic.Core.Buildings
{
    using System;

    public class Headquarters : IBuilding
    {
        private const double BuildTimeCoeff = 1;
        private const double EnergyCoeff = 3.2;
        private const double CrystalCoeff = 1.4;
        private const double MetalCoeff = 2.75;

        public string Name
        {
            get { return "Headquarters"; }
        }

        public string Description { get { return "Integer ornare, eros id sodales ornare, leo purus ultrices justo, sit amet laoreet leo erat eu enim. Quisque odio lacus, semper eget sodales nec, commodo finibus tortor. Vestibulum eu metus a neque gravida faucibus vitae faucibus enim. Nunc orci lacus, malesuada sit amet viverra sit amet, fringilla ut dui. Pellentesque ornare congue ipsum vitae hendrerit. Nam volutpat urna et mi accumsan lacinia. Vivamus at ipsum non nibh cursus commodo ac at risus."; } }

        public int MaxLevel
        {
            get { return 10; }
        }

        public int Prerequisite
        {
            get { return 0; }
        }

        public TimeSpan[] BuildTime
        {
            get
            {
                return new[]
                {
                    TimeSpan.FromMinutes(0),
                    TimeSpan.FromMinutes(0),
                    TimeSpan.FromMinutes(8.3*BuildTimeCoeff),
                    TimeSpan.FromMinutes(26*BuildTimeCoeff),
                    TimeSpan.FromMinutes(43*BuildTimeCoeff),
                    TimeSpan.FromMinutes(59*BuildTimeCoeff),
                    TimeSpan.FromMinutes(72*BuildTimeCoeff),
                    TimeSpan.FromMinutes(121*BuildTimeCoeff),
                    TimeSpan.FromMinutes(215*BuildTimeCoeff),
                    TimeSpan.FromMinutes(305*BuildTimeCoeff),
                    TimeSpan.FromMinutes(465*BuildTimeCoeff),
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
                (int) ((100 * EnergyCoeff) * ((level-1) * 0.75)),
                (int) ((100 * CrystalCoeff) * ((level-1) * 0.75)),
                (int) ((100 * MetalCoeff) * ((level-1) * 0.75))
            };
        }
    }
}
