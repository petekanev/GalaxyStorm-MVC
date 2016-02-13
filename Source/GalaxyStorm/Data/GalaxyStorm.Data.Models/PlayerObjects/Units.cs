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

        public int InterceptorQuantity { get; set; }

        public int DispatchedInterceptors { get; set; }

        public int BomberQuantity { get; set; }

        public int DispatchedBombers { get; set; }

        public int JuggernautQuantity { get; set; }

        public int DispatchedJuggernauts { get; set; }

        public CurrentlyRecruiting CurrentlyRecruiting { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public int AmountRecruiting { get; set; }
    }

    public enum CurrentlyRecruiting
    {
        None = 0,
        Scouts = 1,
        Carriers = 2,
        Fighters = 3,
        Interceptors = 4,
        Bombers = 5,
        Juggernauts = 6
    }
}
