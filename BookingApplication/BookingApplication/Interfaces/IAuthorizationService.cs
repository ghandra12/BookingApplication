using Microsoft.AspNetCore.Identity;

namespace BookingApplication.Interfaces
{
    public interface IAuthorizationService
    {
        public Task<IdentityResult> RegisterAsync(string email, string password);
        public Task<SignInResult> LoginAsync(string email, string password);
    }
}
