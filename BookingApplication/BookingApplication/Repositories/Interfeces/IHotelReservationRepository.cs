using BookingApplication.Models;

namespace BookingApplication.Repositories.Interfeces
{
    public interface IRestaurantReservationRepository : IBaseRepository<RestaurantReservation>
    {
        public IEnumerable<RestaurantReservation> GetByUserId(Guid userId);
    }
}
