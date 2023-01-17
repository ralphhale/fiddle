using IndustrialLighting.Persistence;
using IndustrialLighting.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace IndustrialLighting.Domain.Services
{
    public class MaterialService
    {
        private readonly IndustrialLightingContext _dbContext;

        public MaterialService(IndustrialLightingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Material> CreateAsync(string name)
        {
            var item = new Material
            {
                IsActive = true,
                Name = name
            };

            var result = await _dbContext.Materials
                .AddAsync(item);

            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Material> GetAsync(int id)
        {
            var item = await _dbContext.Materials
                .FirstOrDefaultAsync(item => item.Id == id);

            return item;
        }

        public async Task<List<Material>> ListAsync()
        {
            var items = await _dbContext.Materials
                .OrderBy(item => item.Name)
                .ToListAsync();

            return items;
        }
    }
}