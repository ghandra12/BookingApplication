using BookingApplication.Models;
using BookingApplication.Repositories.Interfeces;
using Microsoft.EntityFrameworkCore;

namespace BookingApplication.Repositories
{
    public class BarbershopReservationRepository : BaseRepository<BarbershopReservation>, IBarbershopReservationRepository
    {
        public BarbershopReservationRepository(BookingContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<BarbershopReservation> GetByUserId(Guid userId)
        {
            var barbershopReservations = dbContext.BarbershopReservations.Include(bar => bar.Barbershop).Where(b => b.UserId == userId);
            return barbershopReservations;
        }
    }
}
