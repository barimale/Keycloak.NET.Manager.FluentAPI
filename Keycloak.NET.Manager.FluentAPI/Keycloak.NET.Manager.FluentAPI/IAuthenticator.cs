using Keycloak.Net.Models.Users;

namespace Keycloak.NET.Manager.FluentAPI
{
    public interface IAuthenticator
    {
        User Authenticate();
    }
}