using Microsoft.AspNetCore.Mvc;

namespace BookingApplication.Repositories.Interfeces
{
    public interface IRepositoryWrapper
    {
        IAccountRepository AccountRepository { get; }
        IBarbershopRepository BarbershopRepository { get; }
        IBarbershopReservationRepository BarbershopReservationRepository { get; }
        IContactRepository ContactRepository { get; }
        ICinemaRepository CinemaRepository { get; }
        ICinemaReservationRepository CinemaReservationRepository { get; }
        IHotelRepository HotelRepository { get; }
        IHotelReservationRepository HotelReservationRepository { get; }
        IRestaurantRepository RestaurantRepository { get; }
        IRestaurantReservationRepository RestaurantReservationRepository { get; }
        void Save();
    }
}
