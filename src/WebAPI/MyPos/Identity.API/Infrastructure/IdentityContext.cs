using Identity.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Identity.API.Infrastructure
{
    public class IdentityContext : DbContext
    {
        public DbSet<Credentials> Credentials { get; set; }

        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Credentials>(entity =>
            {
                entity.ToTable("credentials");
                entity.HasKey(e => e.UserName);
            });
        }
    }
}