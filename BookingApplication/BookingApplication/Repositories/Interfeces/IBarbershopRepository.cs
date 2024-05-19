using BookingApplication.Models;

namespace BookingApplication.Repositories.Interfeces
{
    public interface IBarbershopRepository : IBaseRepository<Barbershop>
    {
        public IEnumerable<Guid> GetIds();
        public Barbershop GetBarbershopById(Guid id);
    }
}
