using Keycloak.Net;
using Keycloak.NET.Manager.FluentAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keycloak.NET.FluentAPI.Configure
{
    internal class Role : IRoles
    {
        private readonly IRealmContext _context;
        private readonly KeycloakClient _client;

        public Role(IRealmContext context)
        {
            _context = context;
            _client = context.Client;
        }

        public async Task<bool> DeleteRoleAsync(string roleName)
        {
            try
            {
                return await _client.DeleteRoleByNameAsync(
                    _context.ConnectionSettings.Realm,
                    _context.ClientId,
                    roleName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AddRoleAsync(string roleName)
        {
            try
            {
                return await _client.CreateRoleAsync(
                    _context.ConnectionSettings.Realm,
                    _context.ClientId,
                    new Net.Models.Roles.Role()
                    {
                        Name = roleName,
                        Composite = false
                    });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Net.Models.Roles.Role>> AllAsync()
        {
            try
            {
                var userId = _context.UserDetails.Id;

                var client = await _client.GetClientsAsync(_context.ConnectionSettings.Realm);
                var clientId = client.FirstOrDefault(p => p.ClientId == _context.ConnectionSettings.ClientName).Id;

                var clientRoles = await _client
                    .GetEffectiveClientRoleMappingsForUserAsync(_context.ConnectionSettings.Realm, userId, clientId);

                var realmRoles = await _client
                    .GetEffectiveRealmRolesForClientScopeForClientAsync(_context.ConnectionSettings.Realm, clientId);

                var clientEntitlements = clientRoles.Where(p => p.Composite != null && !p.Composite.Value).ToList();
                var realmEntitlements = realmRoles.Where(p => p.Composite != null && !p.Composite.Value).ToList();

                return clientEntitlements.Concat(realmEntitlements).ToList();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
