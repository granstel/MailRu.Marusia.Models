using System.Text.Json.Serialization;

namespace MailRu.Marusia.Models.Cards
{
    [JsonConverter(typeof(CardJsonConverter))]
    public interface ICard
    {
        CardType Type { get; }
    }
}
