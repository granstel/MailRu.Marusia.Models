﻿using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MailRu.Marusia.Models
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Nlu
    {
        public ICollection<Entity> Entities { get; set; }
    }
}
