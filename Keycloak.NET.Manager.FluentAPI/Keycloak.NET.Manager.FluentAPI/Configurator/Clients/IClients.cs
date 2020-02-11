using System.Collections.Generic;
using System.Threading.Tasks;

namespace Keycloak.NET.FluentAPI.Configure
{
    public interface IClients
    {
        Task<bool> Create(string clientId, Protocol protocolType, string endpoint = "");
        Task<IEnumerable<Net.Models.Roles.Role>> GetClientRolesNamesAsync(string clientId);
        Task<IEnumerable<Net.Models.Roles.Role>> GetDefaultClientRolesNamesAsync();
        Task<IEnumerable<Net.Models.Roles.Role>> GetClientRoleMappingsForUserAsync();
        Task<bool> AddClientRoleMappingsForUserAsync(string roleName);
    }

    public enum Protocol
    {
        OPENID_CONNECT,
        SAML
    }
}