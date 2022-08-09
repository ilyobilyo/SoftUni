using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SharedTrip.Contracts;
using SharedTrip.Models;
using SharedTrip.Models.Trip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripService tripService;

        public TripsController(Request request, ITripService tripService)
            : base(request)
        {
            this.tripService = tripService;
        }

        [Authorize]
        public Response Add()
            => View();

        [Authorize]
        [HttpPost]
        public Response Add(AddTripViewModel model)
        {
            (bool isValid, IEnumerable<ErrorViewModel> errors) = tripService.ValidateModel(model);

            if (!isValid)
            {
                return View(errors, "/Error");
            }

            try
            {
                tripService.AddTrip(model);
            }
            catch (Exception)
            {
                return View(new List<ErrorViewModel>() { new ErrorViewModel("Unexpected error") }, "/Error");
            }

            return Redirect("/Trips/All");
        }

        [Authorize]
        public Response All()
        {
            List<TripViewModel> trips = tripService.GetAllTrips();

            return View(trips);
        }

        [Authorize]
        public Response Details(string tripId)
        {
            DetailsViewModel model = tripService.GetTripDetails(tripId);

            return View(model);
        }

        [Authorize]
        public Response AddUserToTrip(string tripId)
        {
            try
            {
                tripService.AddUserToTrip(tripId, User.Id);
            }
            catch (ArgumentException aex)
            {
                return View(new List<ErrorViewModel>() { new ErrorViewModel($"{aex.Message}") }, "/Error");
            }

            return Redirect("/Trips/All");
        }
    }
}


