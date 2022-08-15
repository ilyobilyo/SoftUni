using CarShop.ViewModels;
using CarShop.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Contracts
{
    public interface IUserService
    {
        (bool isRegistered, IEnumerable<ErrorViewModel>) Register(RegisterViewModel model);
        string Login(LoginViewModel model);
        bool GetUserTypeIsMechanic(string id);
    }
}
