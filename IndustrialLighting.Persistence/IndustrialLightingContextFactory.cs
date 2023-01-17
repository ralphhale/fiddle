using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IndustrialLighting.Persistence
{
    public class IndustrialLightingContextFactory : IDesignTimeDbContextFactory<IndustrialLightingContext>
    {
        public IndustrialLightingContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IndustrialLightingContext>();

            //optionsBuilder.UseSqlite("Data Source=blog.db");

            return new IndustrialLightingContext(optionsBuilder.Options);
        }
    }
}
