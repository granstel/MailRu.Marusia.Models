using System.Text.Json.Serialization;
using MailRu.Marusia.Models.Interfaces;

namespace MailRu.Marusia.Models
{
    public class MetaModel
    {
        [JsonPropertyName("locale")]
        public string Locale { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        [JsonPropertyName("interfaces")]
        public InterfacesModel Interfaces { get; set; }
    }
}
