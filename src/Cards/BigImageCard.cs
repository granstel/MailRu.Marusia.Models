using System.Text.Json.Serialization;

namespace MailRu.Marusia.Models.Cards
{
    public class BigImageCard : CardItem, ICard
    {
        [JsonPropertyName("type")]
        public CardType Type => CardType.BigImage;
    }
}
