using BookingApplication.Repositories.Interfeces;
using Microsoft.AspNetCore.Mvc;

namespace BookingApplication.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private BookingContext _bookingContext;
        private IAccountRepository? _accountRepository;
        private IContactRepository? _contactRepository;
        private IBarbershopReservationRepository? _barbershopReservationRepository;
        private IBarbershopRepository? _barbershopRepository;


        public IAccountRepository AccountRepository
        {
            get
            {
                if (_accountRepository == null)
                {
                    _accountRepository = new AccountRepository(_bookingContext);
                }

                return _accountRepository;
            }
        }


        public IBarbershopRepository BarbershopRepository
        {
            get
            {
                if (_barbershopRepository == null)
                {
                    _barbershopRepository = new BarbershopRepository(_bookingContext);
                }

                return _barbershopRepository;
            }
        }
        public IBarbershopReservationRepository BarbershopReservationRepository
        {
            get
            {
                if (_barbershopReservationRepository == null)
                {
                    _barbershopReservationRepository = new BarbershopReservationRepository(_bookingContext);
                }

                return _barbershopReservationRepository;
            }
        }
        public IContactRepository ContactRepository
        {
            get
            {
                if (_contactRepository == null)
                {
                    _contactRepository = new ContactRepository(_bookingContext);
                }

                return _contactRepository;
            }
        }
        public RepositoryWrapper(BookingContext bookingContext)
        {
            _bookingContext = bookingContext;
        }

        public void Save()
        {
            _bookingContext.SaveChanges();
        }
    }
}
