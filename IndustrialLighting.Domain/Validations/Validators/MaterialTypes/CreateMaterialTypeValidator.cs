using FluentValidation;
using IndustrialLighting.Persistence;
using IndustrialLighting.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace IndustrialLighting.Domain.Validations.Validators.MaterialTypes
{
    public class CreateMaterialTypeValidator : AbstractValidator<MaterialType>
    {
        public CreateMaterialTypeValidator(IndustrialLightingContext dbContext)
        {
            RuleFor(item => item.Name)
                .Cascade(CascadeMode.Stop)
                .Must(item =>  !string.IsNullOrWhiteSpace(item))
                    .WithMessage("Please specify a Material Type name");

            RuleFor(item => item.Name)
               .MustAsync(async (item, name, cancellationToken) =>
                 {
                     var exists = await dbContext.MaterialTypes
                         .AnyAsync(item => item.Name.ToLower() == name.ToLower());

                     return !exists;
                 })
                    .When(item => !string.IsNullOrWhiteSpace(item.Name))
                    .WithMessage("Please specify a unique Material Type name");
        }
    }
}
