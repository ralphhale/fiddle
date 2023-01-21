using IndustrialLighting.Domain.Exceptions;
using IndustrialLighting.Domain.Validations;
using IndustrialLighting.Persistence;
using IndustrialLighting.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace IndustrialLighting.Domain.Services
{
    public class MaterialTypeService
    {
        private readonly IndustrialLightingContext _dbContext;
        private readonly MaterialTypeValidations _validations;

        public MaterialTypeService(IndustrialLightingContext dbContext, MaterialTypeValidations validations)
        {
            _dbContext = dbContext;
            _validations = validations;
        }

        public async Task<MaterialType> CreateAsync(string name)
        {
            var item = new MaterialType
            {
                IsActive = true,
                Name = name
            };

            var validation = await _validations.Create.ValidateAsync(item);

            if (validation.IsValid)
            {
                var result = await _dbContext.MaterialTypes
                    .AddAsync(item);

                await _dbContext
                    .SaveChangesAsync();

                return result.Entity;
            }
            else
            {
                throw new ValidatorException(validation.Errors);
            }
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