using CarShop.Contracts;
using CarShop.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace CarShop.Services
{
    public class ValidatorService : IValidatorService
    {
        public (bool isValid, IEnumerable<ErrorViewModel> validatonErrors) ValidateModel(object model)
        {
            var context = new ValidationContext(model);
            var errorResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(model, context, errorResult, true);

            if (isValid)
            {
                return (isValid, null);
            }

            var errorList = new List<ErrorViewModel>();

            foreach (var error in errorResult)
            {
                errorList.Add(new ErrorViewModel() { ErrorMessage = error.ErrorMessage });
            }

            return (isValid, errorList);
        }
    }
}
