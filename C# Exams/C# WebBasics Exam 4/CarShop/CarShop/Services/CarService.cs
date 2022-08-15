using CarShop.Contracts;
using CarShop.Data.Common;
using CarShop.Data.Models;
using CarShop.ViewModels;
using CarShop.ViewModels.Car;
using CarShop.ViewModels.Issue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services
{
    public class CarService : ICarService
    {
        private readonly IValidatorService validatorService;
        private readonly IRepository repo;

        public CarService(IValidatorService validatorService, IRepository repo)
        {
            this.validatorService = validatorService;
            this.repo = repo;
        }

        public (bool isAdded, IEnumerable<ErrorViewModel> errors) AddCar(AddCarViewModel model, string userId)
        {
            var (isValid, errorMessages) = validatorService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, errorMessages);
            }

            bool isAdded = true;
            List<ErrorViewModel> dbErrors = new List<ErrorViewModel>();

            var car = new Car()
            {
                Model = model.Model,
                OwnerId = userId,
                Year = model.Year,
                PictureUrl = model.ImageUrl,
                PlateNumber = model.PlateNumber,
            };

            try
            {
                repo.Add(car);
                repo.SaveChanges();
            }
            catch (Exception)
            {
                isAdded = false;

                dbErrors.Add(new ErrorViewModel() { ErrorMessage = "Unexpected error. Database cant save this car!" });
            }

            return (isAdded, dbErrors);
        }

        public IEnumerable<CarViewModel> GetAllCarsWithIssues()
        {
            return repo.All<Car>()
                .Where(x => x.Issues.Any(c => !c.IsFixed))
                .Select(x => new CarViewModel()
                {
                    Id = x.Id,
                    ImageUrl = x.PictureUrl,
                    PlateNumber = x.PlateNumber,
                    Model = x.Model,
                    FixedIssues = x.Issues.Count(i => i.IsFixed),
                    RemainigIssues = x.Issues.Count(i => !i.IsFixed)
                })
                .ToList();
        }

        public IEnumerable<CarViewModel> GetClientCars(string id)
        {
            return repo.All<Car>()
                .Where(x => x.OwnerId == id)
                .Select(x => new CarViewModel()
                {
                    Id = x.Id,
                    ImageUrl = x.PictureUrl,
                    PlateNumber = x.PlateNumber,
                    Model = x.Model,
                    FixedIssues = x.Issues.Count(i => i.IsFixed),
                    RemainigIssues = x.Issues.Count(i => !i.IsFixed)
                })
                .ToList();


        }

        public (bool isClient, IEnumerable<ErrorViewModel> errors) UserIsClient(string userId)
        {
            var user = repo.All<User>()
               .FirstOrDefault(x => x.Id == userId);

            bool isClient = true;
            List<ErrorViewModel> errors = new List<ErrorViewModel>();

            if (user.IsMechanic)
            {
                isClient = false;
                errors.Add(new ErrorViewModel() { ErrorMessage = "User must be a client to add a car!" });
            }

            return (isClient, errors);
        }

    }
}
