using FluentValidation.Results;

namespace IndustrialLighting.Domain.Validations.Extensions
{
    public static class ValidationFailureExtensions
    {
        public static bool HasError(this List<ValidationFailure> errors, string propertyName)
        {
            var hasError = errors?.Any(item => item.PropertyName.ToLower() == propertyName.ToLower()) ?? false;

            return hasError;
        }

        public static string ErrorMessage(this List<ValidationFailure> errors, string propertyName)
        {
            var errorMessage = "";

            if (errors.HasError(propertyName)) 
            {
                errorMessage = errors?.FirstOrDefault(item => item.PropertyName.ToLower() == propertyName.ToLower())?.ErrorMessage ?? "";
            }

            return errorMessage;
        }
    }
}
