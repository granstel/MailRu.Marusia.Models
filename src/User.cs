using System.Text.Json.Serialization;

namespace MailRu.Marusia.Models
{
    public class User
    {
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
    }
}
