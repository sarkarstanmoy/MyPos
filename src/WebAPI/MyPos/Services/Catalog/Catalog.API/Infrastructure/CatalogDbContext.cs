using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infrastructure
{
    public class CatalogDbContext : DbContext
    {
        public DbSet<Models.Catalog> catalogDbSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Catalog>(entity =>
            {
                entity.ToTable("Catalog");
            });
        }
    }
}