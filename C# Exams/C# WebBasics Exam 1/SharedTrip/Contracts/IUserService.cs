using SharedTrip.Models;
using SharedTrip.Models.User;
using System.Collections.Generic;

namespace SharedTrip.Contracts
{
    public interface IUserService
    {
        (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(RegisterViewModel model);
        void RegisterUser(RegisterViewModel model);
        (bool isCorrect, string userId) IsLoginCorrect(LoginViewModel model);
    }
}
