using BookingApplication.Models;
using BookingApplication.Repositories.Interfeces;

namespace BookingApplication.Services
{
    public class ReservationService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ReservationService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public List<ReservationListModel> GetAllReservations(Guid userId)
        {
            var hotelReservations = _repositoryWrapper.HotelReservationRepository.GetByUserId(userId);
            var cinemaReservations = _repositoryWrapper.CinemaReservationRepository.GetByUserId(userId);
            var barbershopReservations = _repositoryWrapper.BarbershopReservationRepository.GetByUserId(userId);
            var restaurantReservations = _repositoryWrapper.RestaurantReservationRepository.GetByUserId(userId);

            var reservationListModel = new List<ReservationListModel>();

            reservationListModel.AddRange(hotelReservations.Select(hr => new ReservationListModel()
            {
                Date = hr.Date,
                Name = hr.Hotel.Name,
                StartHour = hr.StartHour,
                Type = "hotel"
            }));

            reservationListModel.AddRange(cinemaReservations.Select(hr => new ReservationListModel()
            {
                Date = hr.Date,
                Name = hr.Cinema.Name,
                StartHour = hr.StartHour,
                Type = "cinema"
            }));

            reservationListModel.AddRange(barbershopReservations.Select(hr => new ReservationListModel()
            {
                Date = hr.Date,
                Name = hr.Barbershop.Name,
                StartHour = hr.StartHour,
                Type = "barbershop"
            }));

            reservationListModel.AddRange(restaurantReservations.Select(hr => new ReservationListModel()
            {
                Date = hr.Date,
                Name = hr.Restaurant.Name,
                StartHour = hr.StartHour,
                Type = "restaurant"
            }));

            return reservationListModel;
        }
    }
}
