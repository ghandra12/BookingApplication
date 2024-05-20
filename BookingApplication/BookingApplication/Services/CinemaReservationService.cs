using BookingApplication.Models;
using BookingApplication.Repositories.Interfeces;

namespace BookingApplication.Services
{
    public class CinemaReservationService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public CinemaReservationService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public void AddReservation(CinemaReservation CinemaReservation)
        {
            _repositoryWrapper.CinemaReservationRepository.Add(CinemaReservation);
        }

    }
}
