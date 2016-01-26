namespace GalaxyStorm.Web.Utilities
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Hosting;
    using Data;
    using Data.Models;
    using Data.Models.PlayerObjects;
    using Data.Repositories;

    /// <summary>
    /// The PlayerAssigner is responsible for the creation of a player object when a user registers
    /// </summary>
    public class PlayerAssigner
    {
        public static PlayerObject AssignPlayerObject()
        {
            var pO = new PlayerObject();

            pO.Units = new Units
            {
                BomberQuantity = 0,
                CarriersQuantity = 0,
                DispatchedBombers = 0,
                DispatchedCarriers = 0,
                DispatchedFighters = 0,
                DispatchedInterceptors = 0,
                DispatchedJuggernauts = 0,
                DispatchedScouts = 0,
                FighterQuantity = 0,
                InterceptorQuantiy = 0,
                JuggernautQuantity = 0,
                ScoutsQuantity = 0
            };

            pO.Buildings = new Buildings
            {
                HeadQuartersLevel = 1,
                SolarCollectorLevel = 1,
                CrystalExtractorLevel = 1,
                MetalScrapperLevel = 1,
                BarracksLevel = 0,
                ResearchCentreLevel = 0
            };

            pO.Points = new Points();
            pO.Points.PointsCombat = 0;
            pO.Points.PointsNeutral = 0;
            pO.Points.PointsPlanet = (pO.Buildings.HeadQuartersLevel * 100)
                + (pO.Buildings.SolarCollectorLevel * 10)
                + (pO.Buildings.CrystalExtractorLevel * 10)
                + (pO.Buildings.MetalScrapperLevel * 10);

            pO.Resources = new Resources();
            pO.Resources.Energy = 350;
            pO.Resources.Crystal = 350;
            pO.Resources.Metal = 350;

            pO.Technologies = new Technologies();
            pO.Technologies.ArmorFleetLevel = 0;
            pO.Technologies.CheaperFleetLevel = 0;
            pO.Technologies.FasterConstructionLevel = 0;
            pO.Technologies.LargerFleetLevel = 0;
            pO.Technologies.MoreResourcesLevel = 0;

            var planetRepo = new Repository<Planet>(new GalaxyStormDbContext());

            var planet = planetRepo
                .All()
                .Where(x => !x.IsPopulated)
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefault();

            // ensures the planet belongs in the same shard as the player
            //var shard = new Repository<Shard>(new GalaxyStormDbContext());
            //shard.All().FirstOrDefault(x => x.Id == 2).Planets.Where(y => !y.IsPopulated) // get shardId from user
            //    .OrderBy(x => Guid.NewGuid())
            //    .FirstOrDefault();

            planet.IsPopulated = true;

            pO.PlanetId = planet.Id;

            planetRepo.SaveChanges();

            return pO;
        }

        // Check shard integrity and populate shard
        public static void P()
        {
            var shard = new Shard();

            var shardName = System.IO.File.ReadAllLines(HostingEnvironment.MapPath(@"~/App_Data/ShardNames.txt")).OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            var planetNames = System.IO.File.ReadAllLines(HostingEnvironment.MapPath(@"~/App_Data/PlanetNames.txt")).OrderBy(x => Guid.NewGuid()).ToList();

            shard.Title = shardName;

            var maxRows = 10;
            var maxCols = 10;
            var random = new Random();

            for (int i = 0; i < maxRows; i++)
            {
                for (int j = 0; j < maxCols; j++)
                {
                    if (random.Next(0, 101) <= 50)
                    {
                        var planet = new Planet()
                        {
                            X = j,
                            Y = i,
                            Title = planetNames[random.Next(0, planetNames.Count)],
                            EnergyModifier = 1,
                            CrystalModifier = 1,
                            MetalModifier = 1
                        };

                        shard.Planets.Add(planet);
                    }
                }
            }

            var shardRepo = new Repository<Shard>(new GalaxyStormDbContext());

            shardRepo.Add(shard);
            shardRepo.SaveChanges();
        }
    }
}