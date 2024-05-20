using BookingApplication.Models;
using BookingApplication.Repositories.Interfeces;

namespace BookingApplication.Services
{
    public class RestaurantService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public RestaurantService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public void AddRestaurant(Restaurant Restaurant)
        {
            _repositoryWrapper.RestaurantRepository.Add(Restaurant);
        }
        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return _repositoryWrapper.RestaurantRepository.GetAll();
        }
        public IEnumerable<int> GetAllRestaurantIds()
        {
            return _repositoryWrapper.RestaurantRepository.GetIds();
        }
        public bool DeleteRestaurant(int id)
        {
            var Restaurant = _repositoryWrapper.RestaurantRepository.GetRestaurantById(id);
            return _repositoryWrapper.RestaurantRepository.Delete(Restaurant);
        }
        public Restaurant GetRestaurantById(int id)
        {
            return _repositoryWrapper.RestaurantRepository.GetRestaurantById(id);
        }
        public Restaurant UpdateRestaurant(Restaurant Restaurant)
        {
            var RestaurantToUpdate = _repositoryWrapper.RestaurantRepository.GetRestaurantById(Restaurant.Id);
            if (!string.IsNullOrEmpty(Restaurant.Name))
                RestaurantToUpdate.Name = Restaurant.Name;
            if (!string.IsNullOrEmpty(Restaurant.ImgPath))
                RestaurantToUpdate.ImgPath = Restaurant.ImgPath;
            return _repositoryWrapper.RestaurantRepository.Update(RestaurantToUpdate);
        }
    }
}
