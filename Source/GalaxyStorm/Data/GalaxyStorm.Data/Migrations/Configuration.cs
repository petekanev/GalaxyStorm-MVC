namespace GalaxyStorm.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<GalaxyStormDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(GalaxyStormDbContext context)
        {
            if (context.Shards.Any())
            {
                return;
            }

            var shard = new Shard();
            shard.Title = "Nebula X16";
            shard.ShardSize = ShardSize.Medium;

            context.Shards.Add(shard);
            context.SaveChanges();
        }
    }
}
