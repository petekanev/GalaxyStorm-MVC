namespace GalaxyStorm.Web.Utilities
{
    using System;
    using System.Linq;
    using Data;
    using Data.Models;
    using Data.Models.PlayerObjects;
    using Data.Repositories;

    /// <summary>
    /// The PlayerAssigner is responsible for the creation of a player object when a user registers
    /// </summary>
    public class PlayerAssigner
    {
        public static PlayerObject AssignPlayerObject(GalaxyStormDbContext ctx)
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
            pO.Buildings.HeadQuartersLevel = 1;
            pO.Buildings.BarracksLevel = 0;
            pO.Buildings.ResearchCentreLevel = 0;
            pO.Buildings.SolarCollectorLevel = 1;
            pO.Buildings.CrystalExtractorLevel = 1;
            pO.Buildings.MetalScrapperLevel = 1;

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

            // ensures the planet belongs in the same shard as the player
            var shards = new Repository<Shard>(ctx);
            var planets = new Repository<Planet>(ctx);

            var randomShard = shards.All()
                    .Where(x => x.Planets.Any(p => !p.IsPopulated) && !x.IsLocked)
                    .OrderBy(x => Guid.NewGuid())
                    .First();

            var planet = randomShard.Planets.Where(y => !y.IsPopulated)
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefault();

            planet.IsPopulated = true;

            planets.Update(planet);
            planets.SaveChanges();

            pO.PlanetId = planet.Id;

            return pO;
        }
    }
}