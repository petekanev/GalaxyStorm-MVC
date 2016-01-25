namespace GalaxyStorm.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models;
    using Models.PlayerObjects;

    public interface IGalaxyStormDbContext : IDisposable
    {
        int SaveChanges();

        IDbSet<ApplicationUser> Users { get; set; }

        IDbSet<Buildings> Buildings { get; set; }

        IDbSet<Units> Units { get; set; }

        IDbSet<Report> Reports { get; set; }

        IDbSet<PlayerObject> PlayerObjects { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
