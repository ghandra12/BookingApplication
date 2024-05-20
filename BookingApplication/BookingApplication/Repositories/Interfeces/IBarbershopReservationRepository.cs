using BookingApplication.Models;

namespace BookingApplication.Repositories.Interfeces
{
    public interface IBarbershopReservationRepository : IBaseRepository<BarbershopReservation>
    {
        public IEnumerable<BarbershopReservation> GetByUserId(Guid userId);
    }
}
