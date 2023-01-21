using IndustrialLighting.Domain.Validations.Validators.MaterialTypes;

namespace IndustrialLighting.Domain.Validations
{
    public class MaterialTypeValidations
    {
        public CreateMaterialTypeValidator Create { get; private set; }
        public DeleteMaterialTypeValidator Delete { get; private set; }
        public UpdateMaterialTypeValidator Update { get; private set; }

        public MaterialTypeValidations(CreateMaterialTypeValidator createValidator, DeleteMaterialTypeValidator deleteValidator, UpdateMaterialTypeValidator updateValidator)
        {
            Create = createValidator;
            Delete = deleteValidator;
            Update = updateValidator;
        }
    }
}
