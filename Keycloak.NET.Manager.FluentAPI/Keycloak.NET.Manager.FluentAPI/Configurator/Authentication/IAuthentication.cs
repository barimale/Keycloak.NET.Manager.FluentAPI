using Keycloak.Net.Models.AuthenticationManagement;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Keycloak.NET.Manager.FluentAPI.Configurator
{
    public interface IAuthentication
    {
        Task<bool> AddAuthenticationExecutionAsync(string realmName, AuthenticationExecution ae);
        Task<bool> AddAuthenticationFlowExecutionAsync(string realmName, string flowAlias, IDictionary<string, object> dataWithPRovider);
        Task<bool> CreateAuthenticationFlowAsync(string realmName, AuthenticationFlow af);
        Task<bool> DeleteAuthenticationFlowAsync(string realmName, string flowId);
        Task<bool> DeleteAuthenticatorConfigurationAsync(string realmName, string configurationId);
    }
}