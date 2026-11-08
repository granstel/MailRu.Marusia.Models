using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MailRu.Marusia.Models
{
    public class Nlu
    {
        [JsonPropertyName("entities")]
        public ICollection<Entity> Entities { get; set; }
    }
}
