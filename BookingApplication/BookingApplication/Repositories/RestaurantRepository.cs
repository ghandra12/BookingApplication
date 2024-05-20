using BookingApplication.Models;
using BookingApplication.Repositories.Interfeces;

namespace BookingApplication.Repositories
{
    public class RestaurantRepository : BaseRepository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(BookingContext dbContext) : base(dbContext)
        {
        }
        public IEnumerable<int> GetIds()
        {
            var ids = dbContext.Restaurants.Select(b => b.Id);
            return ids;
        }
        public Restaurant GetRestaurantById(int id)
        {
            var Restaurant = dbContext.Restaurants.Where(b => b.Id == id).FirstOrDefault();
            return Restaurant;
        }
    }
}
