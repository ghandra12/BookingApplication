using BookingApplication.Models;
using BookingApplication.Repositories.Interfeces;

namespace BookingApplication.Repositories
{
    public class HotelRepository : BaseRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(BookingContext dbContext) : base(dbContext)
        {
        }
        public IEnumerable<int> GetIds()
        {
            var ids = dbContext.Hotels.Select(b => b.Id);
            return ids;
        }
        public Hotel GetHotelById(int id)
        {
            var Hotel = dbContext.Hotels.Where(b => b.Id == id).FirstOrDefault();
            return Hotel;
        }
    }
}
