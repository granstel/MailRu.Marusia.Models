﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MailRu.Marusia.Models
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class OutputModel
    {
        public Response Response { get; set; }

        public Session Session { get; set; }

        public State SessionState { get; set; }

        public State UserStateUpdate { get; set; }

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
