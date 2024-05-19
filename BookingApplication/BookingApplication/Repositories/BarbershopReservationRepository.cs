using BookingApplication.Models;
using BookingApplication.Repositories.Interfeces;

namespace BookingApplication.Repositories
{
    public class BarbershopReservationRepository : BaseRepository<BarbershopReservation>, IBarbershopReservationRepository
    {
        public BarbershopReservationRepository(BookingContext dbContext) : base(dbContext)
        {
        }
    }
}
