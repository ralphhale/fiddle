using IndustrialLighting.Domain.Services;
using IndustrialLighting.Domain.Validations;
using IndustrialLighting.Domain.Validations.Validators.MaterialTypes;
using Microsoft.Extensions.DependencyInjection;

namespace IndustrialLighting.Domain.Config
{
    public static class DomainIocConfigurer
    {
        public static IServiceCollection ConfigureDomain(this IServiceCollection services)
        {
            services
                .AddTransient<MaterialService>()
                .AddTransient<MaterialTypeService>();

            services
                .AddTransient<CreateMaterialTypeValidator>()
                .AddTransient<MaterialTypeValidations>();
            

            return services;
        }
    }
}
