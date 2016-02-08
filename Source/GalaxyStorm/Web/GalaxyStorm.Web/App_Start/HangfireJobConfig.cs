namespace GalaxyStorm.Web.App_Start
{
    using System.Data.Entity;
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
            var logicProvider = new LogicProvider();

            var users = new Repository<ApplicationUser>(new GalaxyStormDbContext());

            var pOs = users.All().Select(x => x.PlayerObject).ToList();

            foreach (var pO in pOs)
            {
                var levelE = pO.Buildings.SolarCollectorLevel;
                var levelC = pO.Buildings.CrystalExtractorLevel;
                var levelM = pO.Buildings.MetalScrapperLevel;
                var modifier = logicProvider.Technologies.MoreResources.Modifier[pO.Technologies.MoreResourcesLevel]; 

                var energyGeneration = (logicProvider.Buildings.SolarCollector.ResourceGeneration[levelE] * pO.Planet.EnergyModifier) / 60;
                var crystalGeneration = (logicProvider.Buildings.CrystalExtractor.ResourceGeneration[levelC] * pO.Planet.CrystalModifier) / 60;
                var metalGeneration = (logicProvider.Buildings.MetalScrapper.ResourceGeneration[levelM] * pO.Planet.MetalModifier) / 60;

                if (energyGeneration > (long) energyGeneration)
                {
                    pO.Resources.Energy += (long)(energyGeneration + 1) + (long)((energyGeneration + 1) * modifier);
                }
                else
                {
                    pO.Resources.Energy += (long)energyGeneration + (long)(energyGeneration * modifier);
                }

                if (crystalGeneration > (long)crystalGeneration)
                {
                    pO.Resources.Crystal += (long)(crystalGeneration + 1) + (long)((crystalGeneration + 1) * modifier);
                }
                else
                {
                    pO.Resources.Crystal += (long)crystalGeneration + (long)(crystalGeneration * modifier);
                }

                if (metalGeneration > (long)metalGeneration)
                {
                    pO.Resources.Metal += (long)(metalGeneration + 1) + (long)((metalGeneration + 1) * modifier);
                }
                else
                {
                    pO.Resources.Metal += (long)metalGeneration + (long)(metalGeneration * modifier);
                }
            }

            users.SaveChanges();
        }
    }
}