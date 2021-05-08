using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MailRu.Marusia.Models.Cards
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class MiniAppCard : ICard
    {
        public CardType Type => CardType.MiniApp;
        
        public string Url { get; set; }
    }
}