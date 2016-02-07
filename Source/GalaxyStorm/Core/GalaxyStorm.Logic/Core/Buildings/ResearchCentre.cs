namespace GalaxyStorm.Logic.Core.Buildings
{
    using System;

    public class ResearchCentre : IBuilding
    {
        private const double BuildTimeCoeff = 1;
        private const double EnergyCoeff = 5.05;
        private const double CrystalCoeff = 7.33;
        private const double MetalCoeff = 6.15;

        public string Name
        {
            get { return "Research Centre"; }
        }

        public string Description
        {
            get
            {
                return
                    "Suspendisse enim augue, porttitor vel massa ac, luctus laoreet dolor. Aliquam feugiat orci et orci finibus, id maximus erat rutrum. Integer eget congue urna, ac porta lorem. Phasellus semper risus justo, quis faucibus leo tincidunt ut. Integer at posuere elit, in viverra sem. Integer orci felis, dictum nec purus at, vulputate sodales enim. Curabitur vestibulum, enim ut porttitor viverra, libero quam consectetur justo, eu tempus quam sapien et est. Donec molestie diam tempor, semper augue ut, venenatis sapien. Morbi sit amet facilisis lacus, sed gravida dui.";
            }
        }

        public int MaxLevel
        {
            get { return 5; }
        }

        public int Prerequisite
        {
            get { return 5; }
        }

        public TimeSpan[] BuildTime
        {
            get
            {
                return new[]
                {
                    TimeSpan.FromMinutes(0),
                    TimeSpan.FromMinutes(26*BuildTimeCoeff),
                    TimeSpan.FromMinutes(43*BuildTimeCoeff),
                    TimeSpan.FromMinutes(59*BuildTimeCoeff),
                    TimeSpan.FromMinutes(88*BuildTimeCoeff),
                    TimeSpan.FromMinutes(166*BuildTimeCoeff),
                    TimeSpan.FromMinutes(0)
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
                (int) ((100 * EnergyCoeff) * (level * 0.9)),
                (int) ((100 * CrystalCoeff) * (level * 0.9)),
                (int) ((100 * MetalCoeff) * (level * 0.9))
            };
        }
    }
}
