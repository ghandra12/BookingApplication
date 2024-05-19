using BookingApplication.Models;
using BookingApplication.Repositories.Interfeces;

namespace BookingApplication.Repositories
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(BookingContext dbContext) : base(dbContext)
        {
        }
        public IEnumerable<Guid> GetIds()
        {
            var ids = dbContext.ContactMessages.Select(c => c.Id);
            return ids;
        }
        public Contact GetContactById(Guid id)
        {
            var contact = dbContext.ContactMessages.Where(c => c.Id == id).FirstOrDefault();
            return contact;
        }
    }
}
