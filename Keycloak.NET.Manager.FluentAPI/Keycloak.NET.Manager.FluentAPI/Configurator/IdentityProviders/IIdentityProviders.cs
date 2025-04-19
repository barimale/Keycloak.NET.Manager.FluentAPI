using Keycloak.Net.Models.IdentityProviders;
using System.Threading.Tasks;

namespace Keycloak.NET.Manager.FluentAPI.Configurator
{
    public interface IIdentityProviders
    {
        Task<bool> AddIdentityProviderMapperAsync(string realmName, string providerAlias, IdentityProviderMapper mapper);
        Task<bool> CreateIdentityProviderAsync(string realmName, IdentityProvider provider);
        Task<bool> DeleteIdentityProviderAsync(string realmName, string identityProviderAlias);
        Task<bool> DeleteIdentityProviderMapperAsync(string realmName, string providerAlias, string mapperId);
    }
}