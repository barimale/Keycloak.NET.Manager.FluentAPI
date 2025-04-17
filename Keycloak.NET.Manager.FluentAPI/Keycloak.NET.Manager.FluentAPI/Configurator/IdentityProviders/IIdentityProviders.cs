using System.Threading.Tasks;

namespace Keycloak.NET.Manager.FluentAPI.Configurator.IdentityProviders
{
    public interface IIdentityProviders
    {
        Task<bool> DeleteIdentityProviderAsync(string realmName, string identityProviderAlias);

    }
}
