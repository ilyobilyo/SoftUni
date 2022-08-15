using CarShop.ViewModels;

namespace CarShop.Contracts
{
    public interface IValidatorService
    {
        (bool isValid, IEnumerable<ErrorViewModel> validatonErrors) ValidateModel(object model);
    }
}
