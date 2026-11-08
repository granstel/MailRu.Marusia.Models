using System.Text.Json.Serialization;

namespace MailRu.Marusia.Models
{
    public class OutputModel
    {
        [JsonPropertyName("response")]
        public Response Response { get; set; }

        [JsonPropertyName("session")]
        public Session Session { get; set; }

        [JsonPropertyName("session_state")]
        public State SessionState { get; set; }

        [JsonPropertyName("user_state_update")]
        public State UserStateUpdate { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        public void AddToSessionState(string key, object value)
        {
            if (SessionState == null)
            {
                SessionState = new State();
            }

            SessionState.Add(key, value);
        }

        public void AddToUserState(string key, object value)
        {
            if (UserStateUpdate == null)
            {
                UserStateUpdate = new State();
            }

            UserStateUpdate.Add(key, value);
        }
    }
}
