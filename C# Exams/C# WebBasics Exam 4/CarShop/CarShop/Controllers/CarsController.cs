using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using CarShop.Contracts;
using CarShop.ViewModels.Car;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService carService;

        public CarsController(Request request, ICarService carService)
            : base(request)
        {
            this.carService = carService;
        }

        [Authorize]
        public Response Add()
        {
            var (isUserClient, errors) = carService.UserIsClient(User.Id);

            if (!isUserClient)
            {
                return View(errors, "/Error");
            }

            return View(new { IsAuthenticated = true });
        }

        [Authorize]
        public Response All()
        {
            var (isUserClient, errors) = carService.UserIsClient(User.Id);

            var clientCars = carService.GetClientCars(User.Id);

            if (isUserClient)
            {
                return View(new { IsAuthenticated = true, Cars = clientCars });
            }

            var allCars = carService.GetAllCarsWithIssues();

            return View(new { IsAuthenticated = true, Cars = allCars});
        }

        [Authorize]
        [HttpPost]
        public Response Add(AddCarViewModel model)
        {
            var (isAdded, errors) = carService.AddCar(model, User.Id);

            if (!isAdded)
            {
                return View(errors, "/Error");
            }

            return Redirect("/Cars/All");
        }
    }
}
