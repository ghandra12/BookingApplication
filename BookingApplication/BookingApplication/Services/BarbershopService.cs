using BookingApplication.Models;
using BookingApplication.Repositories.Interfeces;

namespace BookingApplication.Services
{
    public class BarbershopService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public BarbershopService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public void AddBarbershop(Barbershop barbershop)
        {
            _repositoryWrapper.BarbershopRepository.Add(barbershop);
        }
        public IEnumerable<Barbershop> GetAllBarbershops()
        {
            return _repositoryWrapper.BarbershopRepository.GetAll();
        }
        public IEnumerable<Guid> GetAllBarbershopIds()
        {
            return _repositoryWrapper.BarbershopRepository.GetIds();
        }
        public bool DeleteBarbershop(Guid id)
        {
            var barbershop = _repositoryWrapper.BarbershopRepository.GetBarbershopById(id);
            return _repositoryWrapper.BarbershopRepository.Delete(barbershop);
        }
        public Barbershop GetBarbershopById(Guid id)
        {
            return _repositoryWrapper.BarbershopRepository.GetBarbershopById(id);
        }
        public Barbershop UpdateBarbershop(Barbershop barbershop)
        {
            var barbershopToUpdate = _repositoryWrapper.BarbershopRepository.GetBarbershopById(barbershop.Id);
            if (!string.IsNullOrEmpty(barbershop.Name))
                barbershopToUpdate.Name = barbershop.Name;
            if (!string.IsNullOrEmpty(barbershop.ImgPath))
                barbershopToUpdate.ImgPath = barbershop.ImgPath;
            return _repositoryWrapper.BarbershopRepository.Update(barbershopToUpdate);
        }
    }
}
