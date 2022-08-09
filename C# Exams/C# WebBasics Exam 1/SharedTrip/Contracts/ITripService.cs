using SharedTrip.Models;
using SharedTrip.Models.Trip;
using System.Collections.Generic;

namespace SharedTrip.Contracts
{
    public interface ITripService
    {
        (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(AddTripViewModel model);
        void AddTrip(AddTripViewModel model);
        List<TripViewModel> GetAllTrips();
        DetailsViewModel GetTripDetails(string tripId);
        void AddUserToTrip(string tripId, string id);
    }
}
