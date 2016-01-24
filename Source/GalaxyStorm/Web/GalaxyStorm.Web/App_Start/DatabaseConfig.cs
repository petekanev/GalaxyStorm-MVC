namespace GalaxyStorm.Web.App_Start
{
    using System.Configuration;
    using System.Data.Entity;
    using Data;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<GalaxyStormDbContext, Configuration>());
            GalaxyStormDbContext.Create().Database.Initialize(true);
        }
    }
}