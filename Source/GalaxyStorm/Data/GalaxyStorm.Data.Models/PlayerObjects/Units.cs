namespace GalaxyStorm.Data.Models.PlayerObjects
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Units
    {
        [Key]
        public int Id { get; set; }

        public int ScoutsQuantity { get; set; }

        public int DispatchedScouts { get; set; }

        public int CarriersQuantity { get; set; }

        public int DispatchedCarriers { get; set; }

        public int FighterQuantity { get; set; }

        public int DispatchedFighters { get; set; }

        public int InterceptorQuantiy { get; set; }

        public int DispatchedInterceptors { get; set; }

        public int BomberQuantity { get; set; }

        public int DispatchedBombers { get; set; }

        public int JuggernautQuantity { get; set; }

        public int DispatchedJuggernauts { get; set; }
    }
}
