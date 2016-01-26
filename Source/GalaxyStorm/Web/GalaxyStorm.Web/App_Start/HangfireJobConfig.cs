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
                var levelE = pO.Buildings.SolarCollectorLevel;
                var levelC = pO.Buildings.CrystalExtractorLevel;
                var levelM = pO.Buildings.MetalScrapperLevel;
                var modifier = TechnologiesBundle.MoreResources.Modifier[pO.Technologies.MoreResourcesLevel];

                var energyGeneration = BuildingsBundle.SolarCollector.ResourceGeneration[levelE] / 60;
                var crystalGeneration = BuildingsBundle.CrystalExtractor.ResourceGeneration[levelC] / 60;
                var metalGeneration = BuildingsBundle.MetalScrapper.ResourceGeneration[levelM] / 60;

                pO.Resources.Energy += energyGeneration + (int)(energyGeneration * modifier);
                pO.Resources.Crystal += crystalGeneration + (int)(crystalGeneration * modifier);
                pO.Resources.Metal += metalGeneration + (int)(metalGeneration * modifier);
            }

            users.SaveChanges();
        }
    }
}