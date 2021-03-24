﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MailRu.Marusia.Models.Cards
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ItemsListCard : ICard
    {
        public CardType Type => CardType.ItemsList;

        public Header Header { get; set; }

        public CardItem[] Items { get; set; }
    }
}
