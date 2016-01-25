namespace GalaxyStorm.Data.Models.PlayerObjects
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [ComplexType]
    public class Points
    {
        [Column("Combat")]
        public int Combat { get; set; }

        [Column("Neutral")]
        public int Neutral { get; set; }

        [Column("Planet")]
        public int Planet { get; set; }
    }
}
