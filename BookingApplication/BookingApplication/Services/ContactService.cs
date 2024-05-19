using BookingApplication.Models;
using BookingApplication.Repositories.Interfeces;

namespace BookingApplication.Services
{
    public class ContactService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ContactService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public void AddMessage(Contact contact)
        {
            _repositoryWrapper.ContactRepository.Add(contact);
        }
        public IEnumerable<Contact> GetAllMessages()
        {
            return _repositoryWrapper.ContactRepository.GetAll();
        }
        public IEnumerable<Guid> GetAllMessagesIds()
        {
            return _repositoryWrapper.ContactRepository.GetIds();
        }
        public bool DeleteMessage(Guid id)
        {
            var contact = _repositoryWrapper.ContactRepository.GetContactById(id);
            return _repositoryWrapper.ContactRepository.Delete(contact);
        }
    }
}
