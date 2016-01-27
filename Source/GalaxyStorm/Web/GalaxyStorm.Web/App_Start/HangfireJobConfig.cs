namespace GalaxyStorm.Web.App_Start
{
    using System.Linq;
    using Data;
    using Data.Models;
    using Data.Repositories;
    using Hangfire;
    using Logic.Core;

    public class HangfireJobConfig
    {
        public static void ConfigureRecurringJobs()
        {
            RecurringJob.AddOrUpdate("resource-handout", () => ResourceHandOut(), Cron.Minutely);
            RecurringJob.Trigger("resource-handout");
        }

        public static void ResourceHandOut()
        {
            var users = new Repository<ApplicationUser>(new GalaxyStormDbContext());

            var pOs = users.All().Select(x => x.PlayerObject).ToList();

            foreach (var pO in pOs)
            {
                var levelE = pO.Buildings.SolarCollector.Level;
                var levelC = pO.Buildings.CrystalExtractor.Level;
                var levelM = pO.Buildings.MetalScrapper.Level;
                var modifier = TechnologiesBundle.MoreResources.Modifier[pO.Technologies.MoreResourcesLevel];

                var energyGeneration = (BuildingsBundle.SolarCollector.ResourceGeneration[levelE] * pO.Planet.EnergyModifier) / 60;
                var crystalGeneration = (BuildingsBundle.CrystalExtractor.ResourceGeneration[levelC] * pO.Planet.CrystalModifier) / 60;
                var metalGeneration = (BuildingsBundle.MetalScrapper.ResourceGeneration[levelM] * pO.Planet.MetalModifier) / 60;

                pO.Resources.Energy += (int)energyGeneration + (int)(energyGeneration * modifier);
                pO.Resources.Crystal += (int)crystalGeneration + (int)(crystalGeneration * modifier);
                pO.Resources.Metal += (int)metalGeneration + (int)(metalGeneration * modifier);
            }

            users.SaveChanges();
        }
    }
}