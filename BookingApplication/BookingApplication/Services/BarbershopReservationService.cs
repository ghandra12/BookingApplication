using BookingApplication.Models;
using BookingApplication.Repositories.Interfeces;

namespace BookingApplication.Services
{
    public class BarbershopReservationService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public BarbershopReservationService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public void AddReservation(BarbershopReservation barbershopReservation)
        {
            _repositoryWrapper.BarbershopReservationRepository.Add(barbershopReservation);
        }

    }
}
