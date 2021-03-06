﻿using Keycloak.Net;
using Keycloak.Net.Models.Common;
using Keycloak.NET.Manager.FluentAPI;
using System.Threading.Tasks;

namespace Keycloak.NET.FluentAPI.Manage.Sessions
{
    internal class Revocation : IRevocation
    {
        private readonly IRealmContext _context;
        private readonly KeycloakClient _client;

        public Revocation(IRealmContext context)
        {
            _context = context;
            _client = context.Client;
        }

        public async Task<GlobalRequestResult> SetToNowAndPushAsync()
        {
            return await _client.PushRealmRevocationPolicyAsync(_context.ConnectionSettings.Realm);
        }
    }
}