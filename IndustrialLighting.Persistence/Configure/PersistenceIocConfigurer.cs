using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IndustrialLighting.Persistence.Configure
{
    public static class PersistenceIocConfigurer
    {
        public static IServiceCollection ConfigurePersistence(this IServiceCollection services, string connectionString)
        {
            services
                .AddTransient<IStartupFilter, MigrationStartupFilter<IndustrialLightingContext>>();

            services
                .AddDbContext<IndustrialLightingContext>(options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}
