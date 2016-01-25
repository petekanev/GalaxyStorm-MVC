namespace GalaxyStorm.Data.Models.PlayerObjects
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [ComplexType]
    public class Points
    {
        [Column("Combat")]
        public int PointsCombat { get; set; }

        [Column("Neutral")]
        public int PointsNeutral { get; set; }

        [Column("Planet")]
        public int PointsPlanet { get; set; }
    }
}
