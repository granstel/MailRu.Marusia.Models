using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MailRu.Marusia.Models
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class EntityValue
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string PatronymicName { get; set; }
    }
}
