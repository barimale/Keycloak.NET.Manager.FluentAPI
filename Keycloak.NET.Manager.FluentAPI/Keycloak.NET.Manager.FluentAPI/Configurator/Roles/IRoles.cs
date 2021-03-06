﻿using Keycloak.NET.Manager.FluentAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Keycloak.NET.FluentAPI.Configure
{
    public interface IRoles
    {
        Task<bool> DeleteRoleAsync(string roleName);
        Task<bool> DeleteRoleAsync(string roleName, string clientId);
        Task<bool> AddRoleAsync(string roleName);
        Task<bool> AddRoleAsync(string roleName, string clientId);
        Task<List<Net.Models.Roles.Role>> AllAsync();
        AttributedRole GetRoleById(string id);
    }
}