using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MailRu.Marusia.Models.Cards
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class LinkCard : ICard
    {
        public CardType Type => CardType.Link;

        public string Url { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public int ImageId { get; set; }
    }
}