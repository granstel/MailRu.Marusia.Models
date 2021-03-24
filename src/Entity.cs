using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MailRu.Marusia.Models
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Entity
    {
        public Token Tokens { get; set; }

        public string Type { get; set; }

        public object Value { get; set; }
    }
}
