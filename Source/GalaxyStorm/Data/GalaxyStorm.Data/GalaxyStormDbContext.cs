namespace GalaxyStorm.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class GalaxyStormDbContext : IdentityDbContext<ApplicationUser>, IGalaxyStormDbContext
    {
        public GalaxyStormDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static GalaxyStormDbContext Create()
        {
            return new GalaxyStormDbContext();
        }
    }
}
