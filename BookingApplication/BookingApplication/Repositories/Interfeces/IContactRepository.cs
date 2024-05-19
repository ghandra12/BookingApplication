using BookingApplication.Models;

namespace BookingApplication.Repositories.Interfeces
{
    public interface IContactRepository : IBaseRepository<Contact>
    {
        public IEnumerable<Guid> GetIds();
        public Contact GetContactById(Guid id);
    }
}
