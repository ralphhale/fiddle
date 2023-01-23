using IndustrialLighting.Domain.Validations.Validators.Materials;

namespace IndustrialLighting.Domain.Validations
{
    public class MaterialValidations
    {
        public CreateMaterialValidator Create { get; private set; }
        public DeleteMaterialValidator Delete { get; private set; }
        public UpdateMaterialValidator Update { get; private set; }

        public MaterialValidations(CreateMaterialValidator createValidator, DeleteMaterialValidator deleteValidator, UpdateMaterialValidator updateValidator)
        {
            Create = createValidator;
            Delete = deleteValidator;
            Update = updateValidator;
        }
    }
}
