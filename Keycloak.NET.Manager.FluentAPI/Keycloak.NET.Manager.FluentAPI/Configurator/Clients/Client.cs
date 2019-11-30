using Keycloak.Net;
using Keycloak.NET.Manager.FluentAPI.Keycloak.NET;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keycloak.NET.FluentAPI.Configure
{
    internal class Client : IClients
    {
        private readonly IRealmContext _context;
        private readonly KeycloakClient _client;

        public Client(IRealmContext context)
        {
            _context = context;
            _client = context.Client;
        }

        public async Task<IList<Net.Models.Roles.Role>> GetDefaultClientRolesNamesAsync()
        {
            var client = await _client
               .GetClientsAsync(_context.ConnectionSettings.Realm, _context.ConnectionSettings.ClientName)
               .ConfigureAwait(false);

            return await GetClientRolesNamesAsync(client.ToList().First().Id);
        }

        public Task<IList<Net.Models.Roles.Role>> GetClientRolesNamesAsync(string clientId)
        {
            return Extensions.GetRoleNamesAsync(
                 clientId,
                 null,
                _context.ConnectionSettings.Url,
                _context.ConnectionSettings.Realm,
                _context.ConnectionSettings.Username,
                _context.ConnectionSettings.Password);
        }

        public async Task<bool> Create(string clientId, Protocol protocolType, string endpoint = "")
        {
            var client = new Net.Models.Clients.Client
            {
                ClientId = clientId,
                Protocol = protocolType.ToString(),
                BaseUrl = endpoint
            };

            return await _client.CreateClientAsync(_context.ConnectionSettings.Realm, client);
        }
    }
}
