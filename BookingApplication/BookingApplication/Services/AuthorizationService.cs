using BookingApplication.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BookingApplication.Services
{
    public class AuthorizationService: IAuthorizationService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthorizationService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterAsync(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);

                await _userManager.AddToRoleAsync(user, "User");
            }
            return result;
        }

        public async Task<SignInResult> LoginAsync(string email, string password)
        {
            return await _signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);
        }
    }
}
