using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MailRu.Marusia.Models.Interfaces
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class InterfacesModel
    {
        public AccountLinking AccountLinking { get; set; }

        public Screen Screen { get; set; }

        public Payments Payments { get; set; }

        public GeolocationSharing GeolocationSharing { get; set; }

        public bool HasScreen()
        {
            return Screen != null;
        }

        public bool HasGeolocationSharing()
        {
            return GeolocationSharing != null;
        }
    }
}
