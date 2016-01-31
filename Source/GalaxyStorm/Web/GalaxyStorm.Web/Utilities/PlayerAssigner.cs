namespace GalaxyStorm.Web.Utilities
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Hosting;
    using Data;
    using Data.Models;
    using Data.Models.PlayerObjects;
    using Data.Models.PlayerObjects.BuildingsComplexTypes;
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

            pO.Buildings = new Buildings();
            pO.Buildings.HeadQuarters = new HeadQuarters {Level = 1};
            pO.Buildings.Barracks = new Barracks {Level = 0};
            pO.Buildings.ResearchCentre = new ResearchCentre {Level = 0};
            pO.Buildings.SolarCollector = new SolarCollector {Level = 1};
            pO.Buildings.CrystalExtractor = new CrystalExtractor {Level = 1};
            pO.Buildings.MetalScrapper = new MetalScrapper {Level = 1};

            pO.Points = new Points();
            pO.Points.PointsCombat = 0;
            pO.Points.PointsNeutral = 0;
            pO.Points.PointsPlanet = (pO.Buildings.HeadQuarters.Level * 100)
                + (pO.Buildings.SolarCollector.Level * 10)
                + (pO.Buildings.CrystalExtractor.Level * 10)
                + (pO.Buildings.MetalScrapper.Level * 10);

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

            // ensures the planet belongs in the same shard as the player
            var shards = new Repository<Shard>(new GalaxyStormDbContext());

            var randomShard = shards.All()
                    .Where(x => x.Planets.Any(p => !p.IsPopulated))
                    .OrderBy(x => Guid.NewGuid())
                    .First();

            pO.ShardId = randomShard.Id;

            var planet = randomShard.Planets.Where(y => !y.IsPopulated)
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefault();

            planet.IsPopulated = true;

            pO.PlanetId = planet.Id;

            return pO;
        }
    }
}