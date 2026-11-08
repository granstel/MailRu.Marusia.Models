using System.Text.Json.Serialization;

namespace MailRu.Marusia.Models
{
    public class Token
    {
        [JsonPropertyName("start")]
        public int Start { get; set; }

        [JsonPropertyName("end")]
        public int End { get; set; }
    }
}
