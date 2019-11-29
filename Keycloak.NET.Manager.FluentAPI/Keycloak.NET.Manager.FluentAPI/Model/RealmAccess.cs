using Newtonsoft.Json;
using System.Collections.Generic;

namespace Keycloak.NET.Manager.FluentAPI.Model
{
    [JsonObject]
    public class RealmRoles
    {
        [JsonProperty("roles")]
        public List<string> Names { get; set; } = new List<string>();
    }
}
