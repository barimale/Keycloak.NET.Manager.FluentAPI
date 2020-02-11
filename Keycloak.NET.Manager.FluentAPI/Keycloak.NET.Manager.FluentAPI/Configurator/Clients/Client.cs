using Keycloak.Net;
using Keycloak.NET.Manager.FluentAPI;
using Keycloak.NET.Manager.FluentAPI.Keycloak.NET;
using System;
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

        public async Task<IEnumerable<Net.Models.Roles.Role>> GetDefaultClientRolesNamesAsync()
        {
            var client = await _client
               .GetClientsAsync(_context.ConnectionSettings.Realm, _context.ConnectionSettings.ClientName)
               .ConfigureAwait(false);

            return await GetClientRolesNamesAsync(client.ToList().First().Id);
        }

        public Task<IEnumerable<Net.Models.Roles.Role>> GetClientRolesNamesAsync(string clientId)
        {
            return Extensions.GetRoleNamesAsync(
                 clientId,
                 null,
                _context.ConnectionSettings.Url,
                _context.ConnectionSettings.Realm,
                _context.ConnectionSettings.Username,
                _context.ConnectionSettings.Password);
        }

        public Task<bool> Create(string clientId, Protocol protocolType, string endpoint = "")
        {
            var client = new Net.Models.Clients.Client
            {
                ClientId = clientId,
                Protocol = protocolType.ToString(),
                BaseUrl = endpoint
            };

            return _client.CreateClientAsync(_context.ConnectionSettings.Realm, client);
        }

        public Task<IEnumerable<Net.Models.Roles.Role>> GetClientRoleMappingsForUserAsync(string userId)
        {
            try
            {
                return _context.Client.GetClientRoleMappingsForUserAsync(
                    _context.ConnectionSettings.Realm,
                    userId,
                    _context.ClientId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Net.Models.Roles.Role>> GetAvailableClientRoleMappingsForUserAsync(string userId)
        {
            try
            {
                return await _context.Client.GetAvailableClientRoleMappingsForUserAsync(
                    _context.ConnectionSettings.Realm,
                    userId,
                    _context.ClientId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AddClientRoleMappingsForUserAsync(string roleName, string userId)
        {
            try
            {
                var avaliableRoles = await _context.Client.GetAvailableClientRoleMappingsForUserAsync(
                    _context.ConnectionSettings.Realm,
                    userId,
                    _context.ClientId);

                var roleToAdd = avaliableRoles.FirstOrDefault(p => p.Name == roleName);

                if (roleToAdd == null)
                    throw new ArgumentNullException("roleToAdd");

                return await _context.Client.AddClientRoleMappingsToUserAsync(
                    _context.ConnectionSettings.Realm,
                    userId,
                    _context.ClientId,
                    new List<Net.Models.Roles.Role>()
                    { 
                        roleToAdd
                    });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteClientRoleMappingsForUserAsync(string roleName, string userId)
        {
            var rolesToRemove = await GetClientRoleMappingsForUserAsync(userId);
            var result = rolesToRemove.Where(p => p.Name == roleName).ToList();

            return await _context.Client.DeleteClientRoleMappingsFromUserAsync(
                    _context.ConnectionSettings.Realm,
                    userId,
                    _context.ClientId,
                    result);
        }
    }
}