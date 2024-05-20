using BookingApplication.Models;
using BookingApplication.Repositories.Interfeces;
using Microsoft.EntityFrameworkCore;

namespace BookingApplication.Repositories
{
    public class CinemaReservationRepository : BaseRepository<CinemaReservation>, ICinemaReservationRepository
    {
        public CinemaReservationRepository(BookingContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<CinemaReservation> GetByUserId(Guid userId)
        {
            var cinemaReservations = dbContext.CinemaReservations.Include(c => c.Cinema).Where(b => b.UserId == userId);
            return cinemaReservations;
        }
    }
}
