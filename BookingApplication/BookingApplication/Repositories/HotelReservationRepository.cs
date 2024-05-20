using BookingApplication.Models;
using BookingApplication.Repositories.Interfeces;
using Microsoft.EntityFrameworkCore;

namespace BookingApplication.Repositories
{
    public class HotelReservationRepository : BaseRepository<HotelReservation>, IHotelReservationRepository
    {
        public HotelReservationRepository(BookingContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<HotelReservation> GetByUserId(Guid userId)
        {
            var hotelReservations = dbContext.HotelReservations.Include(hot => hot.Hotel).Where(b => b.UserId == userId);
            return hotelReservations;
        }
    }
}
