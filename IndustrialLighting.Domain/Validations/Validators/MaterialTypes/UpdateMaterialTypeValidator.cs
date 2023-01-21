using FluentValidation;
using IndustrialLighting.Persistence;
using IndustrialLighting.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace IndustrialLighting.Domain.Validations.Validators.MaterialTypes
{
    public class UpdateMaterialTypeValidator : AbstractValidator<MaterialType>
    {
        public UpdateMaterialTypeValidator(IndustrialLightingContext dbContext)
        {
            RuleFor(item => item.Name)
                .Cascade(CascadeMode.Stop)
                .Must(item => !string.IsNullOrWhiteSpace(item))
                    .WithMessage("Please specify a Material Type name");

            RuleFor(item => item.Name)
                .Cascade(CascadeMode.Stop)
                .MustAsync(async (item, name, cancellationToken) =>
                 {
                     var id = item.Id;

                     var exists = await dbContext.MaterialTypes
                         .AnyAsync(item => item.Id != id && item.Name.ToLower() == name.ToLower());

                     return !exists;
                 })
                    .When(item => !string.IsNullOrEmpty(item.Name))
                    .WithMessage("Please specify a unique Material Type name");
        }
    }
}
