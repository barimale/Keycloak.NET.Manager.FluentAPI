using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Keycloak.Net.Common.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Keycloak.NET.Manager.FluentAPI.Keycloak.NET
{
    public static class Extensions
    {
        private static readonly ISerializer s_serializer = new NewtonsoftJsonSerializer(new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
        });

        static Extensions()
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
            string password) => new Url(url)
                .AppendPathSegment("/auth")
                .ConfigureRequest(settings => settings.JsonSerializer = s_serializer)
                .WithAuthentication(getToken, url, authenticationRealm, userName, password);

        public static Task<IEnumerable<Net.Models.Roles.Role>> GetRoleNamesAsync(
            string clientId,
            Func<string> getToken, 
            string url,
            string realm, 
            string userName, 
            string password)
        {
            return GetBaseUrl(realm, getToken, url, realm, userName, password)
                    .AppendPathSegment($"/admin/realms/{realm}/clients/{clientId}/roles")
                    .GetJsonAsync<IEnumerable<Net.Models.Roles.Role>>();
        }
    }
}