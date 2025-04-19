using Keycloak.Net;
using Keycloak.Net.Models.IdentityProviders;
using Keycloak.NET.Manager.FluentAPI;
using System;
using System.Threading.Tasks;

namespace Keycloak.NET.Manager.FluentAPI.Configurator
{
    internal class IdentityProviders : IIdentityProviders
    {
        private readonly KeycloakClient _client;

        public IdentityProviders(IRealmContext context)
        {
            _client = context.Client;
        }

        public async Task<bool> DeleteIdentityProviderAsync(string realmName, string identityProviderAlias)
        {
            try
            {
                return await _client.DeleteIdentityProviderAsync(realmName, identityProviderAlias);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> CreateIdentityProviderAsync(string realmName, IdentityProvider provider)
        {
            try
            {
                return await _client.CreateIdentityProviderAsync(realmName, provider);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AddIdentityProviderMapperAsync(string realmName, string providerAlias, IdentityProviderMapper mapper)
        {
            try
            {
                return await _client.AddIdentityProviderMapperAsync(realmName, providerAlias, mapper);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteIdentityProviderMapperAsync(string realmName, string providerAlias, string mapperId)
        {
            try
            {
                return await _client.DeleteIdentityProviderMapperAsync(realmName, providerAlias, mapperId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}