using Newtonsoft.Json;
using System.Collections.Generic;

namespace Keycloak.NET.Manager.FluentAPI.Model
{
    [JsonObject]
    public abstract class BaseRoles
    {
        [JsonProperty("roles")]
        public List<string> Names { get; set; } = new List<string>();
    }
}
