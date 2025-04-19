using Keycloak.Net;
using Keycloak.Net.Models.AuthenticationManagement;
using Keycloak.NET.Manager.FluentAPI;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Keycloak.NET.Manager.FluentAPI.Configurator
{
    internal class Authentication : IAuthentication
    {
        private readonly KeycloakClient _client;

        public Authentication(IRealmContext context)
        {
            _client = context.Client;
        }

        public async Task<bool> AddAuthenticationExecutionAsync(string realmName, AuthenticationExecution ae)
        {
            try
            {
                return await _client.AddAuthenticationExecutionAsync(realmName, ae);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AddAuthenticationFlowExecutionAsync(string realmName, string flowAlias, IDictionary<string, object> dataWithPRovider)
        {
            try
            {
                return await _client.AddAuthenticationFlowExecutionAsync(realmName, flowAlias, dataWithPRovider);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> CreateAuthenticationFlowAsync(string realmName, AuthenticationFlow af)
        {
            try
            {
                return await _client.CreateAuthenticationFlowAsync(realmName, af);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAuthenticationFlowAsync(string realmName, string flowId)
        {
            try
            {
                return await _client.DeleteAuthenticationFlowAsync(realmName, flowId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAuthenticatorConfigurationAsync(string realmName, string configurationId)
        {
            try
            {
                return await _client.DeleteAuthenticatorConfigurationAsync(realmName, configurationId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}