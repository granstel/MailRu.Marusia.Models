using System.Text.Json.Serialization;

namespace MailRu.Marusia.Models.Buttons
{
    public class CardButton : Button
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}
