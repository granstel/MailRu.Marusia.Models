using System.Text.Json.Serialization;

namespace MailRu.Marusia.Models.Input
{
    public class InputSession : Session
    {
        [JsonPropertyName("new")]
        public bool New { get; set; }

        [JsonPropertyName("skill_id")]
        public string SkillId { get; set; }
    }
}
