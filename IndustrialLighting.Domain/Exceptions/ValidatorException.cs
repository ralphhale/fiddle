using FluentValidation.Results;

namespace IndustrialLighting.Domain.Exceptions
{
    public class ValidatorException : Exception
    {
        public List<ValidationFailure> Errors { get; private set; }

        public ValidatorException(List<ValidationFailure> errors) : base("")
        {
            Errors = errors;
        }
    }
}
