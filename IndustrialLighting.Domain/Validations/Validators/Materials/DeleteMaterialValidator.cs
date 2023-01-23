using FluentValidation;
using IndustrialLighting.Persistence;
using IndustrialLighting.Persistence.Entities;

namespace IndustrialLighting.Domain.Validations.Validators.Materials
{
    public class DeleteMaterialValidator : AbstractValidator<Material>
    {
        public DeleteMaterialValidator(IndustrialLightingContext dbContext)
        {
        }
    }
}
