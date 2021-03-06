﻿using Keycloak.Net.Models.Users;
using Keycloak.NET.FluentAPI.Base;
using Keycloak.NET.FluentAPI.Configure;
using Keycloak.NET.FluentAPI.Manage;

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