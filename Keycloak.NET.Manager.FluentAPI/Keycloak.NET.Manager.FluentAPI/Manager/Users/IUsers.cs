using Keycloak.Net.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Keycloak.NET.FluentAPI.Manage.Sessions
{
    public interface IUsers
    {
        Task<IEnumerable<User>> ViewAllUsersAsync();
        Task<bool> UnlockUsersAsync();
        Task<bool> AddUserAsync(User user);
        Task<User> GetUserAsync(string userId);
    }
}