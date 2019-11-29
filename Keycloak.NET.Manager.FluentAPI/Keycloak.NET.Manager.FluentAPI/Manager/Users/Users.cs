using Keycloak.Net;
using Keycloak.Net.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Keycloak.NET.FluentAPI.Manage.Sessions
{
    internal class Users : IUsers
    {
        private readonly IRealmContext _context;
        private readonly KeycloakClient _client;

        public Users(IRealmContext context)
        {
            _context = context;
            _client = _context.Client;
        }

        public Task<bool> AddUserAsync(User user)
        {
            return _client.CreateUserAsync(_context.ConnectionSettings.Realm, user);
        }

        public async Task<bool> UnlockUsersAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> ViewAllUsersAsync()
        {
            return _client.GetUsersAsync(_context.ConnectionSettings.Realm);
        }

        public Task<User> GetUserAsync(string userId)
        {
            return _client.GetUserAsync(_context.ConnectionSettings.Realm, userId);
        }
    }
}
