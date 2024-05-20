using BookingApplication.Models;
using BookingApplication.Repositories.Interfeces;

namespace BookingApplication.Services
{
    public class HotelService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public HotelService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public void AddHotel(Hotel Hotel)
        {
            _repositoryWrapper.HotelRepository.Add(Hotel);
        }
        public IEnumerable<Hotel> GetAllHotels()
        {
            return _repositoryWrapper.HotelRepository.GetAll();
        }
        public IEnumerable<int> GetAllHotelIds()
        {
            return _repositoryWrapper.HotelRepository.GetIds();
        }
        public bool DeleteHotel(int id)
        {
            var Hotel = _repositoryWrapper.HotelRepository.GetHotelById(id);
            return _repositoryWrapper.HotelRepository.Delete(Hotel);
        }
        public Hotel GetHotelById(int id)
        {
            return _repositoryWrapper.HotelRepository.GetHotelById(id);
        }
        public Hotel UpdateHotel(Hotel Hotel)
        {
            var HotelToUpdate = _repositoryWrapper.HotelRepository.GetHotelById(Hotel.Id);
            if (!string.IsNullOrEmpty(Hotel.Name))
                HotelToUpdate.Name = Hotel.Name;
            if (!string.IsNullOrEmpty(Hotel.ImgPath))
                HotelToUpdate.ImgPath = Hotel.ImgPath;
            return _repositoryWrapper.HotelRepository.Update(HotelToUpdate);
        }
    }
}
