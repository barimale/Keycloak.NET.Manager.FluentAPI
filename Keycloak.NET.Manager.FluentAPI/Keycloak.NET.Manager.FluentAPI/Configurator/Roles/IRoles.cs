using System.Collections.Generic;
using System.Threading.Tasks;

namespace Keycloak.NET.FluentAPI.Configure
{
    public interface IRoles
    {
        Task<bool> DeleteRoleAsync(string roleName);
        Task<bool> AddRoleAsync(string roleName);
        Task<List<Net.Models.Roles.Role>> AllAsync();
    }
}