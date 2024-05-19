using Microsoft.AspNetCore.Mvc;

namespace BookingApplication.Repositories.Interfeces
{
    public interface IRepositoryWrapper
    {
        IAccountRepository AccountRepository { get; }
        IBarbershopRepository BarbershopRepository { get; }
        IBarbershopReservationRepository BarbershopReservationRepository { get; }
        IContactRepository ContactRepository { get; }

        void Save();
    }
}
