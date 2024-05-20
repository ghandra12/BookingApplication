using BookingApplication.Models;

namespace BookingApplication.Repositories.Interfeces
{
    public interface IHotelRepository : IBaseRepository<Hotel>
    {
        public IEnumerable<int> GetIds();
        public Hotel GetHotelById(int id);
    }
}
