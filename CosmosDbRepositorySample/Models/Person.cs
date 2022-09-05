using Microsoft.Azure.CosmosRepository;
using Newtonsoft.Json;

namespace CosmosDbRepositorySample.Models
{
    public class Person : Item
    {
        [JsonProperty("firstName")]
        public string? FirstName { get; set; }

        [JsonProperty("lastName")]
        public string? LastName { get; set; }

        [JsonProperty("customer")]
        public CustomerObject Customer { get; set; } = null!;

        public class CustomerObject
        {
            [JsonProperty("id")]
            public string Id { get; set; } = null!;

            [JsonProperty("name")]
            public string Name { get; set; } = null!;
        }
    }
}
