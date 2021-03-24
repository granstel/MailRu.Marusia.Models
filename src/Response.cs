using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using MailRu.Marusia.Models.Buttons;
using MailRu.Marusia.Models.Cards;

namespace MailRu.Marusia.Models
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Response
    {
        public string Text { get; set; }

        public string Tts { get; set; }

        public ResponseButton[] Buttons { get; set; }

        public bool EndSession { get; set; }
        
        public ICard Card { get; set; }
    }
}
