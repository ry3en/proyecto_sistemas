using Microsoft.AspNetCore.Identity;
using proyecto_sistemas.Shared.Entities;
using proyecto_sistetmas.API.Migrations;

namespace proyecto_sistemas.Api.Helpers
{
    public interface IUserHelper
    {
        Task<User?> GetUserAsync(string email);
        Task<IdentityResult> AddUserAsync(User user, string password);
        Task CheckRoleAsync(string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);
    }
}