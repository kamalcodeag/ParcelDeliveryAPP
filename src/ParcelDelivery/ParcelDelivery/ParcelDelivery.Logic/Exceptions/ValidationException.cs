using FluentValidation.Results;

namespace ParcelDelivery.Logic.Exceptions
{
    public class ValidationException : BaseException
    {
        public List<string>? ValdationErrors { get; set; }
        
        public ValidationException()
        {
            Message = "Validation errors";
        }

        public ValidationException(ValidationResult validationResult)
        {
            ValdationErrors = new List<string>();

            foreach (var validationError in validationResult.Errors)
            {
                ValdationErrors.Add(validationError.ErrorMessage);
            }
        }
    }
}