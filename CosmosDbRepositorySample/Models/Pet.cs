using Microsoft.Azure.CosmosRepository;
using Newtonsoft.Json;

namespace CosmosDbRepositorySample.Models
{
    public class Pet : Item
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("animalType")]
        public string AnimalType { get; set; } = null!;

        [JsonProperty("owner")]
        public OwnerObject Owner { get; set; } = null!;

        protected override string GetPartitionKeyValue() => Owner.Id;

        public class OwnerObject
        {
            [JsonProperty("id")]
            public string Id { get; set; } = null!;

            [JsonProperty("name")]
            public string Name { get; set; } = null!;
        }
    }
}
