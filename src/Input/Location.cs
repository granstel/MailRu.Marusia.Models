﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MailRu.Marusia.Models.Input
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Location
    {
        public float Lat { get; set; }

        public float Lon { get; set; }

        public float Accuracy { get; set; }
    }
}
