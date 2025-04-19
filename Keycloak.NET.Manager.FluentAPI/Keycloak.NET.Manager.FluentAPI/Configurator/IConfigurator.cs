using Keycloak.NET.FluentAPI.Configure;

namespace Keycloak.NET.Manager.FluentAPI.Configurator
{
    public interface IConfigurator
    {
        IClients Clients { get; }
        IClientScopes ClientScopes { get; }
        IRoles Roles { get; }
        IIdentityProviders IdentityProviders { get; }
        IAuthentication Authentication { get; }
    }
}