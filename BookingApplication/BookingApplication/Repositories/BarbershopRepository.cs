using BookingApplication.Models;
using BookingApplication.Repositories.Interfeces;

namespace BookingApplication.Repositories
{
    public class BarbershopRepository : BaseRepository<Barbershop>, IBarbershopRepository
    {
        public BarbershopRepository(BookingContext dbContext) : base(dbContext)
        {
        }
        public IEnumerable<Guid> GetIds()
        {
            var ids = dbContext.Barbershops.Select(b => b.Id);
            return ids;
        }
        public Barbershop GetBarbershopById(Guid id)
        {
            var barbershop = dbContext.Barbershops.Where(b => b.Id == id).FirstOrDefault();
            return barbershop;
        }
    }
}
