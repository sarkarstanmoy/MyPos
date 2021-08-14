using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infrastructure
{
    public class CatalogDbContext : DbContext
    {
        public DbSet<Models.Catalog> catalogDbSet { get; set; }
        public DbSet<Item> ItemDbSet { get; set; }

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Catalog>(entity =>
            {
                entity.ToTable("Catalog");
                entity.HasKey(e => e.CatalogId);
                entity.HasMany(e => e.Items).WithOne();
            });

            modelBuilder.Entity<Models.Item>(entity =>
            {
                entity.ToTable("Item");
                entity.HasKey(e => e.ItemId);
            });
        }
    }
}