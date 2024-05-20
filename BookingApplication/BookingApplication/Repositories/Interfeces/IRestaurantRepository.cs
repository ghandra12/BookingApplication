using BookingApplication.Models;

namespace BookingApplication.Repositories.Interfeces
{
    public interface IRestaurantRepository : IBaseRepository<Restaurant>
    {
        public IEnumerable<int> GetIds();
        public Restaurant GetRestaurantById(int id);
    }
}
