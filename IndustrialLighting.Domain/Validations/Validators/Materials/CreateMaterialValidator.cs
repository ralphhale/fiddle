using FluentValidation;
using IndustrialLighting.Persistence;
using IndustrialLighting.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace IndustrialLighting.Domain.Validations.Validators.Materials
{
    public class CreateMaterialValidator : AbstractValidator<Material>
    {
        public CreateMaterialValidator(IndustrialLightingContext dbContext)
        {
            RuleFor(item => item.Name)
                .Cascade(CascadeMode.Stop)
                .Must(item => !string.IsNullOrWhiteSpace(item))
                .WithMessage("Please specify a name");

            RuleFor(item => item.Name)
                .MustAsync(async (item, name, cancellationToken) =>
                {
                    var exists = await dbContext.Materials
                        .AnyAsync(item => item.Name.ToLower() == name.ToLower());

                    return !exists;
                })
                .When(item => !string.IsNullOrWhiteSpace(item.Name))
                .WithMessage("Please specify a unique name");

            RuleFor(item => item.Price)
                .Cascade(CascadeMode.Stop)
                .Must(item => item > 0)
                .WithMessage("Please specify a price");

            RuleFor(item => item.TypeId)
                .Cascade(CascadeMode.Stop)
                .Must(item => item != 0)
                .WithMessage("Please specify a material type");

            RuleFor(item => item.TypeId)
                .MustAsync(async (item, typeId, cancellationToken) =>
                {
                    var exists = await dbContext.MaterialTypes
                        .AnyAsync(item => item.Id == typeId);

                    return exists;
                })
                .When(item => item.Id != 0)
                .WithMessage("Please specify a valid material type");
        }
    }
}
