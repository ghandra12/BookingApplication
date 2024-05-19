using BookingApplication.Models;
using BookingApplication.Repositories.Interfeces;

namespace BookingApplication.Repositories
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(BookingContext dbContext) : base(dbContext)
        {
        }
    }
}
