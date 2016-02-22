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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Planet>()
                .HasRequired(x => x.Shard)
                .WithMany(x => x.Planets)
                .WillCascadeOnDelete(false); 
            
            modelBuilder.Entity<ApplicationUser>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<PlayerObject>()
                .HasOptional(a => a.ApplicationUser)
                .WithMany()
                .HasForeignKey(u => u.ApplicationUserId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Planet>()
                .HasKey(x => x.Id)
                .HasOptional(a => a.PlayerObject)
                .WithMany()
                .HasForeignKey(u => u.PlayerObjectId)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<GalaxyStorm.ViewModels.Shards.ShardViewModel> ShardViewModels { get; set; }
    }
}
