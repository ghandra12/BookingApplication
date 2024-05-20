using BookingApplication.Models;

namespace BookingApplication.Repositories.Interfeces
{
    public interface ICinemaRepository : IBaseRepository<Cinema>
    {
        public IEnumerable<int> GetIds();
        public Cinema GetCinemaById(int id);
    }
}
