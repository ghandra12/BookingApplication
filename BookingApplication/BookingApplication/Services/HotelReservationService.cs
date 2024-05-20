using BookingApplication.Models;
using BookingApplication.Repositories.Interfeces;

namespace BookingApplication.Services
{
    public class HotelReservationService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public HotelReservationService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public void AddReservation(HotelReservation HotelReservation)
        {
            _repositoryWrapper.HotelReservationRepository.Add(HotelReservation);
        }

    }
}
