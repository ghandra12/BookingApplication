using BookingApplication.Models;
using BookingApplication.Repositories.Interfeces;
using Microsoft.EntityFrameworkCore;

namespace BookingApplication.Repositories
{
    public class RestaurantReservationRepository : BaseRepository<RestaurantReservation>, IRestaurantReservationRepository
    {
        public RestaurantReservationRepository(BookingContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<RestaurantReservation> GetByUserId(Guid userId)
        {
            var restaurantReservations = dbContext.RestaurantReservations.Include(res => res.Restaurant).Where(b => b.UserId == userId);
            return restaurantReservations;
        }
    }
}
