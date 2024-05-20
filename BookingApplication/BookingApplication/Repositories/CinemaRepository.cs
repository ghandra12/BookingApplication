using BookingApplication.Models;
using BookingApplication.Repositories.Interfeces;

namespace BookingApplication.Repositories
{
    public class CinemaRepository : BaseRepository<Cinema>, ICinemaRepository
    {
        public CinemaRepository(BookingContext dbContext) : base(dbContext)
        {
        }
        public IEnumerable<int> GetIds()
        {
            var ids = dbContext.Cinemas.Select(b => b.Id);
            return ids;
        }
        public Cinema GetCinemaById(int id)
        {
            var Cinema = dbContext.Cinemas.Where(b => b.Id == id).FirstOrDefault();
            return Cinema;
        }
    }
}
