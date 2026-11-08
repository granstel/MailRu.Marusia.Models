using System.Text.Json.Serialization;

namespace MailRu.Marusia.Models.Cards
{
    [JsonConverter(typeof(JsonStringEnumConverter<CardType>))]
    public enum CardType
    {
        BigImage,

        ItemsList,

        MiniApp,

        Link
    }
}
