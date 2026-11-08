using System.Text.Json.Serialization;

namespace MailRu.Marusia.Models.Input
{
    public class InputState
    {
        [JsonPropertyName("session")]
        public State Session { get; set; }

        [JsonPropertyName("user")]
        public State User { get; set; }
    }
}
