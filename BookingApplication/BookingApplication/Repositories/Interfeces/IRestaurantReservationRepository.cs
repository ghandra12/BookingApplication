using BookingApplication.Models;

namespace BookingApplication.Repositories.Interfeces
{
    public interface IHotelReservationRepository : IBaseRepository<HotelReservation>
    {
        public IEnumerable<HotelReservation> GetByUserId(Guid userId);
    }
}
