namespace GalaxyStorm.Logic.Core
{
    using Ships;

    public class ShipsBundle
    {
        static ShipsBundle()
        {
            Bomber = new Bomber();
            Carrier = new Carrier();
            Fighter = new Fighter();
            Interceptor = new Interceptor();
            Juggernaut = new Juggernaut();
            Scout = new Scout();
        }

        public static Bomber Bomber { get; set; }

        public static Carrier Carrier { get; set; }

        public static Fighter Fighter { get; set; }

        public static Interceptor Interceptor { get; set; }

        public static Juggernaut Juggernaut { get; set; }

        public static Scout Scout { get; set; }
    }
}
