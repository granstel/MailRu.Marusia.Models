using System.Text.Json.Serialization;

namespace MailRu.Marusia.Models.Cards
{
    public class LinkCard : ICard
    {
        [JsonPropertyName("type")]
        public CardType Type => CardType.Link;

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("image_id")]
        public int ImageId { get; set; }
    }
}
