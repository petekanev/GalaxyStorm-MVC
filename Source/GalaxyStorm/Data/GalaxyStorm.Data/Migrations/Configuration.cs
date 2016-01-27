namespace GalaxyStorm.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
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
            SeedShard(context);
            SeedAdmins(context);
        }

        private void SeedShard(GalaxyStormDbContext context)
        {
            if (context.Shards.Any())
            {
                return;
            }

            var shard = new Shard();
            shard.Title = "Nebula X16";
            shard.ShardSize = ShardSize.Medium;
            shard.BuildSpeed = 1;

            context.Shards.Add(shard);
            context.SaveChanges();
        }

        private void SeedAdmins(GalaxyStormDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Regular" });
                roleManager.Create(new IdentityRole { Name = "Admiral" });
            }

            if (!context.Users.Any(u => u.UserName == "pip3r4o"))
            {
                var user = new ApplicationUser
                {
                    Email = "pip3r4o@gmail.com",
                    UserName = "pip3r4o",
                };

                userManager.Create(user, "123456");

                userManager.AddToRoles(user.Id, "Regular", "Admiral");
            }
        }
    }
}
