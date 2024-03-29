﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MailRu.Marusia.Models.Buttons
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ResponseButton : Button
    {
        public string Title { get; set; }

        public bool Hide { get; set; }
    }
}
