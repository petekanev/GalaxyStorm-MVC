namespace GalaxyStorm.Web.Utilities
{
    using Data.Models.PlayerObjects;

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
            pO.Resources.Energy = 150; 
            pO.Resources.Crystal = 150;
            pO.Resources.Metal = 150;

            pO.Technologies = new Technologies();
            pO.Technologies.ArmorFleetLevel = 0;
            pO.Technologies.CheaperFleetLevel = 0;
            pO.Technologies.FasterConstructionLevel = 0;
            pO.Technologies.LargerFleetLevel = 0;
            pO.Technologies.MoreResourcesLevel = 0;

            return pO;
        }
    }
}