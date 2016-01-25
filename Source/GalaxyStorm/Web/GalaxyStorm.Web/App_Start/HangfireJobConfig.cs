namespace GalaxyStorm.Web.App_Start
{
    using System.Linq;
    using Data;
    using Data.Models;
    using Data.Repositories;
    using Hangfire;
    using Logic.Core.Buildings;
    using Logic.Core.Technologies;

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

            var solarB = new SolarCollector();
            var crystalE = new CrystalExtractor();
            var metalS = new MetalScrapper();

            var resourceTech = new MoreResources();

            foreach (var pO in pOs)
            {
                var levelE = pO.Buildings.SolarCollectorLevel;
                var levelC = pO.Buildings.CrystalExtractorLevel;
                var levelM = pO.Buildings.MetalScrapperLevel;
                var modifier = resourceTech.Modifier[pO.Technologies.MoreResourcesLevel];

                var energyGeneration = solarB.ResourceGeneration[levelE] / 60;
                var crystalGeneration = crystalE.ResourceGeneration[levelC] / 60;
                var metalGeneration = metalS.ResourceGeneration[levelM] / 60;

                pO.Resources.Energy += energyGeneration + (int)(energyGeneration * modifier);
                pO.Resources.Crystal += crystalGeneration + (int)(crystalGeneration * modifier);
                pO.Resources.Metal += metalGeneration + (int)(metalGeneration * modifier);
            }

            users.SaveChanges();
        }
    }
}