using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using MailRu.Marusia.Models.Buttons;

namespace MailRu.Marusia.Models.Cards
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Footer : Header
    {
        public CardButton Button { get; set; }
    }
}
