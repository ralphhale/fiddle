using IndustrialLighting.Domain.Exceptions;
using IndustrialLighting.Persistence;
using IndustrialLighting.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace IndustrialLighting.Domain.Services
{
    public class MaterialTypeService
    {
        private readonly IndustrialLightingContext _dbContext;

        public MaterialTypeService(IndustrialLightingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MaterialType> CreateAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new InvalidArgumentException("Please specify a material type name");
            }

            var exists = await _dbContext.MaterialTypes
                .AnyAsync(item => item.Name.ToLower() == name.ToLower());

            if (exists)
            {
                throw new InvalidArgumentException("Please specify a unique material type name");
            }

            var item = new MaterialType
            {
                IsActive = true,
                Name = name
            };

            var result = await _dbContext.MaterialTypes
                .AddAsync(item);

            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<MaterialType> GetAsync(int id)
        {
            var item = await _dbContext.MaterialTypes
                .FirstOrDefaultAsync(item => item.Id == id);

            return item;
        }

        public async Task<List<MaterialType>> ListAsync()
        {
            var items = await _dbContext.MaterialTypes
                .OrderBy(item => item.Name)
                .ToListAsync();

            return items;
        }
    }
}