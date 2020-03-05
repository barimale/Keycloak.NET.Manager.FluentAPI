using Newtonsoft.Json;
using System.Collections.Generic;

namespace Keycloak.NET.Client.FluentAPI.Model
{
    [JsonObject]
    public class AtributedRole
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("composite")]
        public bool? Composite { get; set; }
        [JsonProperty("clientRole")]
        public bool? ClientRole { get; set; }
        [JsonProperty("containerId")]
        public string ContainerId { get; set; }
        [JsonProperty("attributes")]
        public Dictionary<string,string> Attributes { get; set; }
    }
}
