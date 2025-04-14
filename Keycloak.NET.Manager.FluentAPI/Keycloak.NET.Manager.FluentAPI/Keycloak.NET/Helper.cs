using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Keycloak.Net.Common.Extensions;
using Keycloak.Net.Models.Roles;
using Keycloak.NET.Manager.FluentAPI.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Extensions
{
    public static class Helper
    {
        private static readonly ISerializer s_serializer = new NewtonsoftJsonSerializer(new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
        });

        static Helper()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
            };
        }

        private static IFlurlRequest GetBaseUrl(
            string authenticationRealm,
            Func<string> getToken,
            string url,
            string realm,
            string userName,
            string password,
            string clientSecret,
            string defaultPathSegment = "/auth") => new Url(url)
                .AppendPathSegment(defaultPathSegment)
                .ConfigureRequest(settings => settings.JsonSerializer = s_serializer)
                .WithAuthentication(getToken, url, authenticationRealm, userName, password, clientSecret);

        public static Task<IEnumerable<Role>> GetRoleNamesAsync(
            string clientId,
            Func<string> getToken,
            string url,
            string realm,
            string userName,
            string password,
            string clientSecret,
            string defaultPathSegment = "auth")
        {
            return GetBaseUrl(realm, getToken, url, realm, userName, password, clientSecret, defaultPathSegment)
                    .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/roles")
                    .GetJsonAsync<IEnumerable<Role>>();
        }

        public static async Task<AttributedRole> GetRoleByNameAsync(
            string clientId,
            Func<string> getToken,
            string url,
            string realm,
            string userName,
            string password,
            string roleName,
            string clientSecret,
            string defaultPathSegment = "auth")
        {
            return await GetBaseUrl(realm, getToken, url, realm, userName, password, clientSecret, defaultPathSegment)
                            .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/roles/{roleName}")
                            .GetJsonAsync<AttributedRole>()
                            .ConfigureAwait(false);
        }
    }
}