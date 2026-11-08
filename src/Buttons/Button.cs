using System.Text.Json.Serialization;

namespace MailRu.Marusia.Models.Buttons
{
    [JsonDerivedType(typeof(CardButton))]
    [JsonDerivedType(typeof(ResponseButton))]
    public abstract class Button
    {
        [JsonPropertyName("payload")]
        [JsonConverter(typeof(ObjectValueJsonConverter))]
        public object Payload { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
