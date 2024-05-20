using BookingApplication.Models;
using BookingApplication.Repositories.Interfeces;

namespace BookingApplication.Services
{
    public class RestaurantReservationService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public RestaurantReservationService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public void AddReservation(RestaurantReservation RestaurantReservation)
        {
            _repositoryWrapper.RestaurantReservationRepository.Add(RestaurantReservation);
        }

    }
}

