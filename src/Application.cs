using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MailRu.Marusia.Models
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Application
    {
        public string ApplicationId { get; set; }

        /// <summary>
        /// Recommend to get values from <see cref="ApplicationTypes"/>
        /// </summary>
        public string ApplicationType { get; set; }
    }
}
