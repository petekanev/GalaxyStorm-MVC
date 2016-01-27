namespace GalaxyStorm.Logic.Core
{
    using Ships;

    public class ShipsBundle
    {
        public ShipsBundle()
        {
            Bomber = new Bomber();
            Carrier = new Carrier();
            Fighter = new Fighter();
            Interceptor = new Interceptor();
            Juggernaut = new Juggernaut();
            Scout = new Scout();
        }

        public Bomber Bomber { get; set; }

        public Carrier Carrier { get; set; }

        public Fighter Fighter { get; set; }

        public Interceptor Interceptor { get; set; }

        public Juggernaut Juggernaut { get; set; }

        public Scout Scout { get; set; }
    }
}
