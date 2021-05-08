using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MailRu.Marusia.Models.Cards
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CardType
    {
        BigImage,

        ItemsList,

        MiniApp
    }
}
