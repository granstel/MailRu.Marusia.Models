using System.Text.Json.Serialization;
using MailRu.Marusia.Models.Buttons;
using MailRu.Marusia.Models.Cards;

namespace MailRu.Marusia.Models
{
    public class Response
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("tts")]
        public string Tts { get; set; }

        [JsonPropertyName("buttons")]
        public ResponseButton[] Buttons { get; set; }

        [JsonPropertyName("end_session")]
        public bool EndSession { get; set; }

        [JsonPropertyName("card")]
        public ICard Card { get; set; }
    }
}
