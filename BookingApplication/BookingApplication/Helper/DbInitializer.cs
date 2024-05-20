using Microsoft.AspNetCore.Identity;

namespace BookingApplication.Helper
{
    public static class DbInitializer
    {
        public static async Task Initialize(IServiceProvider serviceProvider, UserManager<IdentityUser> userManager)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roleNames = { "Admin", "User" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    // Create the roles and seed them to the database
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Here you can create a super user who will maintain the web app
            var powerUser = new IdentityUser
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
            };

            string userPassword = "Password123!";
            var user = await userManager.FindByEmailAsync("admin@admin.com");

            if (user == null)
            {
                var createPowerUser = await userManager.CreateAsync(powerUser, userPassword);
                if (createPowerUser.Succeeded)
                {
                    // Assign the new user the "Admin" role 
                    await userManager.AddToRoleAsync(powerUser, "Admin");
                }
            }
        }
    }
}
