using System.Text.Json.Serialization;

namespace MailRu.Marusia.Models.Interfaces
{
    public class InterfacesModel
    {
        [JsonPropertyName("screen")]
        public Screen Screen { get; set; }

        [JsonPropertyName("payments")]
        public Payments Payments { get; set; }
    }
}
