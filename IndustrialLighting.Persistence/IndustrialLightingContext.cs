using IndustrialLighting.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace IndustrialLighting.Persistence
{
    public class IndustrialLightingContext : DbContext
    {
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialType> MaterialTypes { get; set; }

        public IndustrialLightingContext(DbContextOptions<IndustrialLightingContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Material>()
                .HasKey(item => item.Id);

            modelBuilder.Entity<Material>()
               .HasOne(item => item.Type);

            modelBuilder.Entity<Material>()
                .Property(item => item.Price)
                .HasPrecision(18, 2);
        }
    }
}