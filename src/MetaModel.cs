using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using MailRu.Marusia.Models.Interfaces;

namespace MailRu.Marusia.Models
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class MetaModel
    {
        public string Locale { get; set; }

        public string Timezone { get; set; }

        public string ClientId { get; set; }

        public InterfacesModel Interfaces { get; set; }
    }
}
