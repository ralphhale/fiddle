using IndustrialLighting.Domain.Validations.Validators.MaterialTypes;

namespace IndustrialLighting.Domain.Validations
{
    public class MaterialTypeValidations
    {
        public CreateMaterialTypeValidator Create { get; private set; }

        public MaterialTypeValidations(CreateMaterialTypeValidator createValidator)
        {
            Create = createValidator;
        }
    }
}
