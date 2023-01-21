using FluentValidation;
using IndustrialLighting.Persistence;
using IndustrialLighting.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace IndustrialLighting.Domain.Validations.Validators.MaterialTypes
{
    public class DeleteMaterialTypeValidator : AbstractValidator<MaterialType>
    {
        public DeleteMaterialTypeValidator(IndustrialLightingContext dbContext)
        {
            _ = RuleFor(item => item.Id)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (item, id, cancellationToken) =>
                 {
                     var isInUse = await dbContext.Materials
                         .AnyAsync(item => item.Type.Id == id);

                     return !isInUse;
                 })
                    .When(item => !string.IsNullOrEmpty(item.Name))
                    .WithMessage("Can not delete this Material Type because it is being used by an existing Material");
        }
    }
}
