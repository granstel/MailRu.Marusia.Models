using System.Text.Json.Serialization;

namespace MailRu.Marusia.Models.Buttons
{
    public class ResponseButton : Button
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("hide")]
        public bool Hide { get; set; }
    }
}
