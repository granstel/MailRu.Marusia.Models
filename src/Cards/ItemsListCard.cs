using System.Text.Json.Serialization;

namespace MailRu.Marusia.Models.Cards
{
    public class ItemsListCard : ICard
    {
        [JsonPropertyName("type")]
        public CardType Type => CardType.ItemsList;

        [JsonPropertyName("items")]
        public CardItem[] Items { get; set; }
    }
}
