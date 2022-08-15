using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using CarShop.Contracts;
using CarShop.Data.Models;
using CarShop.ViewModels.Issue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IIssueService issueService;
        private readonly ICarService carService;
        private readonly IUserService userService;
        public IssuesController(Request request, IIssueService issueService, ICarService carService, IUserService userService) 
            : base(request)
        {
            this.issueService = issueService;
            this.userService = userService;
            this.carService = carService;
        }

        [Authorize]
        public Response Add(string carId)
        {
            return View(new AddIssueViewModel() { CarId = carId});
        }

        [Authorize]
        public Response CarIssues(string carId)
        {
            var carIssues = issueService.GetAllIssues(carId);

            return View(carIssues);
        }

        [Authorize]
        [HttpPost]
        public Response Add(AddIssueFormViewModel model)
        {
            var (isIssueAdded, errors) = issueService.AddIssue(model);

            return Redirect($"/Issues/CarIssues?carId={model.CarId}");
        }

        [Authorize]
        public Response Fix(string carId, string issueId)
		{
            var (isFixed, error) = issueService.Fix(carId, issueId, User.Id);

			if (!isFixed)
			{
                return View(error, "/Error");
			}

            return Redirect($"/Issues/CarIssues?carId={carId}");
		}

        [Authorize]
        public Response Delete(string carId, string issueId)
		{
            var (isDeleted, error) = issueService.Delete(carId, issueId);

            if (!isDeleted)
			{
                return View(error, "/Error");
			}

            return Redirect($"/Issues/CarIssues?carId={carId}");
		}
    }
}
