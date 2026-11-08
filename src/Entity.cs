using System.Text.Json.Serialization;

namespace MailRu.Marusia.Models
{
    public class Entity
    {
        [JsonPropertyName("tokens")]
        public Token Tokens { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("value")]
        [JsonConverter(typeof(ObjectValueJsonConverter))]
        public object Value { get; set; }
    }
}
