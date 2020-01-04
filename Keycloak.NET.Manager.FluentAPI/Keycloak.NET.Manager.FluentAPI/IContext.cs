using Keycloak.NET.FluentAPI.Base;
using Keycloak.NET.FluentAPI.Realms;

namespace Keycloak.NET.Manager.FluentAPI
{
    public interface IContext : IBaseContext
    {
        IRealm Realm { get; }
    }
}