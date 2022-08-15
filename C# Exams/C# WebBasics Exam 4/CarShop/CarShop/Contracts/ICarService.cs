using CarShop.Data.Models;
using CarShop.ViewModels;
using CarShop.ViewModels.Car;
using CarShop.ViewModels.Issue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Contracts
{
    public interface ICarService
    {
        (bool isAdded, IEnumerable<ErrorViewModel> errors) AddCar(AddCarViewModel model, string userId);

        (bool isClient, IEnumerable<ErrorViewModel> errors) UserIsClient(string userId);
        IEnumerable<CarViewModel> GetClientCars(string id);
        IEnumerable<CarViewModel> GetAllCarsWithIssues();

    }
}
