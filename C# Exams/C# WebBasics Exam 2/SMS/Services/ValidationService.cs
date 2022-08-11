using SMS.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SMS.Services
{
    public class ValidationService : IValidationService
    {
        public (bool IsValid, string validationError) ValidateModel(object model)
        {
            var context = new ValidationContext(model);
            var errorResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(model, context, errorResult, true);

            if (isValid)
            {
                return (isValid, null);
            }

            string error = string.Join(", ", errorResult.Select(x => x.ErrorMessage));

            return (isValid, error);
        }
    }
}
