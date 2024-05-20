using BookingApplication.Models;

namespace BookingApplication.Repositories.Interfeces
{
    public interface ICinemaReservationRepository : IBaseRepository<CinemaReservation>
    {
        public IEnumerable<CinemaReservation> GetByUserId(Guid userId);
    }
}
