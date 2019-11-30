using System.Collections.Generic;
using System.Threading.Tasks;

namespace Keycloak.NET.FluentAPI.Configure
{
    public interface IClients
    {
        Task<bool> Create(string clientId, Protocol protocolType, string endpoint = "");
        Task<IList<Net.Models.Roles.Role>> GetClientRolesNamesAsync(string clientId);
        Task<IList<Net.Models.Roles.Role>> GetDefaultClientRolesNamesAsync();
    }

    public enum Protocol
    {
        OPENID_CONNECT,
        SAML
    }
}