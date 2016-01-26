namespace GalaxyStorm.Web.Utilities
{
    using System;
    using System.Linq;
    using System.Web.Hosting;
    using Data.Models;

    public class PlanetAllocator
    {
        public static void AllocatePlanets(Shard shard)
        {
            var shardName = System.IO.File.ReadAllLines(HostingEnvironment.MapPath(@"~/App_Data/ShardNames.txt")).OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            var planetNames = System.IO.File.ReadAllLines(HostingEnvironment.MapPath(@"~/App_Data/PlanetNames.txt")).OrderBy(x => Guid.NewGuid()).ToList();

            shard.Title = shardName;

            var maxRows = 5;
            var maxCols = 5;

            switch (shard.ShardSize)
            {
                case ShardSize.Medium:
                    maxRows = 7;
                    maxCols = 7;
                    break;
                case ShardSize.Large:
                    maxRows = 10;
                    maxCols = 10;
                    break;
                case ShardSize.Gigantic:
                    maxRows = 15;
                    maxCols = 15;
                    break;
                default:
                    break;
            }

            var random = new Random();

            var xOffset = random.Next(-10, 750);
            var yOffset = random.Next(-10, 750);

            for (int i = 0; i < maxRows; i++)
            {
                for (int j = 0; j < maxCols; j++)
                {
                    if (random.Next(0, 101) <= 50)
                    {
                        var planet = new Planet
                        {
                            X = j + xOffset,
                            Y = i + yOffset,
                            Title = planetNames[random.Next(0, planetNames.Count)],
                            EnergyModifier = 1,
                            CrystalModifier = 1,
                            MetalModifier = 1
                        };

                        shard.Planets.Add(planet);
                    }
                }
            }
        }
    }
}