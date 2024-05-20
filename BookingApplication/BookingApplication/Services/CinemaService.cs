using BookingApplication.Models;
using BookingApplication.Repositories.Interfeces;

namespace BookingApplication.Services
{
    public class CinemaService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public CinemaService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public void AddCinema(Cinema Cinema)
        {
            _repositoryWrapper.CinemaRepository.Add(Cinema);
        }
        public IEnumerable<Cinema> GetAllCinemas()
        {
            return _repositoryWrapper.CinemaRepository.GetAll();
        }
        public IEnumerable<int> GetAllCinemaIds()
        {
            return _repositoryWrapper.CinemaRepository.GetIds();
        }
        public bool DeleteCinema(int id)
        {
            var Cinema = _repositoryWrapper.CinemaRepository.GetCinemaById(id);
            return _repositoryWrapper.CinemaRepository.Delete(Cinema);
        }
        public Cinema GetCinemaById(int id)
        {
            return _repositoryWrapper.CinemaRepository.GetCinemaById(id);
        }
        public Cinema UpdateCinema(Cinema Cinema)
        {
            var CinemaToUpdate = _repositoryWrapper.CinemaRepository.GetCinemaById(Cinema.Id);
            if (!string.IsNullOrEmpty(Cinema.Name))
                CinemaToUpdate.Name = Cinema.Name;
            if (!string.IsNullOrEmpty(Cinema.ImgPath))
                CinemaToUpdate.ImgPath = Cinema.ImgPath;
            return _repositoryWrapper.CinemaRepository.Update(CinemaToUpdate);
        }
    }
}
