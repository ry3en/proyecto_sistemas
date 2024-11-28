using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using proyecto_sistemas.Shared.Entities;
using proyecto_sistemas.API;
using proyecto_sistetmas.API;

namespace proyecto_sistemas.Api.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly DataContext dbContext;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        // Constructor to inject the required services
        public UserHelper(
            DataContext context,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.dbContext = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        // Get user by email
        public async Task<User?> GetUserAsync(string email)
        {
            return await dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        // Add a new user with a password
        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            var result = await userManager.CreateAsync(user, password);
            return result;
        }

        // Check if a role exists, create it if not
        public async Task CheckRoleAsync(string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                // Create the role if it does not exist
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        // Check if a user is in a specific role
        public async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            return await userManager.IsInRoleAsync(user, roleName);
        }
    }
}
