using Keycloak.Net.Models.Users;
using Keycloak.NET.FluentAPI.Base;
using Keycloak.NET.FluentAPI.Manage;
using Keycloak.NET.Manager.FluentAPI.Configurator;

namespace Keycloak.NET.Manager.FluentAPI
{
    public interface IRealmContext : IBaseContext
    {
        string ClientId { get; }
        IConfigurator Configurator { get; }
        IManager Manager { get; }
        User UserDetails { get; }
    }
}