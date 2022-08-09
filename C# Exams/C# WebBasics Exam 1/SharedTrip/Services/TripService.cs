using SharedTrip.Contracts;
using SharedTrip.Data.Common;
using SharedTrip.Data.Models;
using SharedTrip.Models;
using SharedTrip.Models.Trip;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Services
{
    public class TripService : ITripService
    {
        private readonly IRepository repo;

        public TripService(IRepository repo)
        {
            this.repo = repo;
        }

        public void AddTrip(AddTripViewModel model)
        {
            Trip trip = new Trip()
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = DateTime.ParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                Seats = model.Seats,
                Description = model.Description,
                ImagePath = model.ImagePath,
            };

            repo.Add(trip);
            repo.SaveChanges();
        }

        public void AddUserToTrip(string tripId, string id)
        {
            var trip = repo.All<Trip>()
                .Where(x => x.Id == tripId)
                .FirstOrDefault();

            var user = repo.All<User>()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (user != null || trip == null)
            {
                throw new ArgumentException("User of trip was not found");
            }

            user.UserTrips.Add(new UserTrip()
            {
                TripId = tripId,
                Trip = trip,
                User = user,
                UserId = id
            });

            repo.SaveChanges();
        }

        public List<TripViewModel> GetAllTrips()
        {
            return repo.All<Trip>()
                .Select(x => new TripViewModel()
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Seats = x.Seats,
                })
                .ToList();
        }

        public DetailsViewModel GetTripDetails(string tripId)
        {
            return repo.All<Trip>()
                .Where(x => x.Id == tripId)
                .Select(x => new DetailsViewModel()
                {
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    ImagePath = x.ImagePath,
                    DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Description = x.Description,
                    Seats = x.Seats,
                    Id = x.Id
                })
                .FirstOrDefault();
        }

        public (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(AddTripViewModel model)
        {
            bool isValid = true;
            var errors = new List<ErrorViewModel>();

            if (string.IsNullOrWhiteSpace(model.StartPoint))
            {
                isValid = false;
                errors.Add(new ErrorViewModel("StartPint is required"));
            }

            if (string.IsNullOrWhiteSpace(model.EndPoint))
            {
                isValid = false;
                errors.Add(new ErrorViewModel("EndPoint is required"));
            }

            var isDepartureTimeValid = DateTime.TryParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out var departureTime);

            if (!isDepartureTimeValid)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("DepartureTime must be a valid date"));
            }

            if (model.Seats < 2 || model.Seats > 6)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Seats must be between 2 and 6 seats"));
            }

            if (model.Description == null ||
                model.Description.Length > 80)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Description is required and must be maximun 80 charcters long"));
            }

            return (isValid, errors);
        }


    }
}
