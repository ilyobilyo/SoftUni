using FootballManager.Contracts;
using System.ComponentModel.DataAnnotations;

namespace FootballManager.Services
{
    public class ValidatorService : IValidatorService
    {
        public bool ValidateModel(object model)
        {
            var context = new ValidationContext(model);

            bool isValid = Validator.TryValidateObject(model, context, null, true);

            return isValid;
        }
    }
}
