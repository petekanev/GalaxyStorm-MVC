namespace GalaxyStorm.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.PlayerObjects;

    public class GalaxyStormDbContext : IdentityDbContext<ApplicationUser>, IGalaxyStormDbContext
    {
        public GalaxyStormDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Buildings> Buildings { get; set; }

        public IDbSet<Units> Units { get; set; }

        public IDbSet<Report> Reports { get; set; }

        public IDbSet<PlayerObject> PlayerObjects { get; set; }

        public IDbSet<Planet> Planets { get; set; }

        public IDbSet<Shard> Shards { get; set; }

        public static GalaxyStormDbContext Create()
        {
            return new GalaxyStormDbContext();
        }
    }
}
