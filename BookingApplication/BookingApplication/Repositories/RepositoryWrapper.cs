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
        private ICinemaRepository? _cinemaRepository;
        private ICinemaReservationRepository? _cinemaReservationRepository;
        private IRestaurantRepository? _restaurantRepository;
        private IRestaurantReservationRepository? _restaurantReservationRepository;
        private IHotelRepository? _hotelRepository;
        private IHotelReservationRepository? _hotelReservationRepository;

        public IRestaurantReservationRepository RestaurantReservationRepository
        {
            get
            {
                if (_restaurantReservationRepository == null)
                {
                    _restaurantReservationRepository = new RestaurantReservationRepository(_bookingContext);
                }

                return _restaurantReservationRepository;
            }
        }
        public ICinemaReservationRepository CinemaReservationRepository
        {
            get
            {
                if (_cinemaReservationRepository == null)
                {
                    _cinemaReservationRepository = new CinemaReservationRepository(_bookingContext);
                }

                return _cinemaReservationRepository;
            }
        }
        public IRestaurantRepository RestaurantRepository
        {
            get
            {
                if (_restaurantRepository == null)
                {
                    _restaurantRepository = new RestaurantRepository(_bookingContext);
                }

                return _restaurantRepository;
            }
        }

        public IHotelRepository HotelRepository
        {
            get
            {
                if (_hotelRepository == null)
                {
                    _hotelRepository = new HotelRepository(_bookingContext);
                }

                return _hotelRepository;
            }
        }

        public IHotelReservationRepository HotelReservationRepository
        {
            get
            {
                if (_hotelReservationRepository == null)
                {
                    _hotelReservationRepository = new HotelReservationRepository(_bookingContext);
                }

                return _hotelReservationRepository;
            }
        }

        public ICinemaRepository CinemaRepository
        {
            get
            {
                if (_cinemaRepository == null)
                {
                    _cinemaRepository = new CinemaRepository(_bookingContext);
                }

                return _cinemaRepository;
            }
        }
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
