using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MailRu.Marusia.Models.Interfaces
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class InterfacesModel
    {
        public Screen Screen { get; set; }

        public Payments Payments { get; set; }

        public bool HasScreen()
        {
            return Screen != null;
        }
    }
}
