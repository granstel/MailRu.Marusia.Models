using System.Text.Json.Serialization;

namespace MailRu.Marusia.Models.Cards
{
    public class MiniAppCard : ICard
    {
        [JsonPropertyName("type")]
        public CardType Type => CardType.MiniApp;

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
