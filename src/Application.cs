using System.Text.Json.Serialization;

namespace MailRu.Marusia.Models
{
    public class Application
    {
        [JsonPropertyName("application_id")]
        public string ApplicationId { get; set; }

        /// <summary>
        /// Recommend to get values from <see cref="ApplicationTypes"/>
        /// </summary>
        [JsonPropertyName("application_type")]
        public string ApplicationType { get; set; }
    }
}
