using IndustrialLighting.Domain.Exceptions;
using IndustrialLighting.Domain.Validations;
using IndustrialLighting.Persistence;
using IndustrialLighting.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace IndustrialLighting.Domain.Services
{
    public class MaterialService
{
        private readonly IndustrialLightingContext _dbContext;
        private readonly MaterialValidations _validations;

        public MaterialService(IndustrialLightingContext dbContext, MaterialValidations validations)
        {
            _dbContext = dbContext;
            _validations = validations;
        }

        public async Task<Material> CreateAsync(int typeId, string name, decimal price)
        {
            var item = new Material
            {
                IsActive = true,
                Name = name,
                Price = price,
                TypeId = typeId
            };

            var validation = await _validations.Create.ValidateAsync(item);

            if (validation.IsValid)
            {
                var result = await _dbContext.Materials
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

        public async Task DeleteAsync(int id)
        {
            var item = new Material
            {
                Id = id
            };

            var validation = await _validations.Delete.ValidateAsync(item);

            if (validation.IsValid)
            {
                var local = _dbContext.Materials
                    .Local
                    .FirstOrDefault(entry => entry.Id.Equals(id));

                if (local != null)
                {
                    // detach
                    _dbContext.Entry(local).State = EntityState.Detached;
                }

                _dbContext.Materials
                    .Attach(item);

                _dbContext.Materials
                    .Remove(item);

                await _dbContext
                    .SaveChangesAsync();
            }
            else
            {
                throw new ValidatorException(validation.Errors);
            }
        }

        public async Task<Material> GetAsync(int id)
        {
            var item = await _dbContext.Materials
                .AsNoTracking()
                .FirstOrDefaultAsync(item => item.Id == id);

            return item;
        }

        public async Task<List<Material>> ListAsync()
        {
            var items = await _dbContext.Materials
                .AsNoTracking()
                .Include(item => item.Type)
                .OrderBy(item => (item.Type != null ? item.Type.Name : ""))
                .ThenBy(item => item.Name)
                .ToListAsync();

            return items;
        }

        public async Task<Material> UpdateAsync(Material material)
        {
            var validation = await _validations.Update.ValidateAsync(material);

            if (validation.IsValid)
            {
                var item = await _dbContext.Materials
                    .FirstOrDefaultAsync(item => item.Id == material.Id);

                item.IsActive = material.IsActive;
                item.Name = material.Name;
                item.Price = material.Price;
                item.TypeId = material.TypeId;

                await _dbContext
                    .SaveChangesAsync();

                return item;
            }
            else
            {
                throw new ValidatorException(validation.Errors);
            }
        }
    }
}