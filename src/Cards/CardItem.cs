using System.Text.Json.Serialization;

namespace MailRu.Marusia.Models.Cards
{
    [JsonDerivedType(typeof(BigImageCard))]
    public class CardItem
    {
        [JsonPropertyName("image_id")]
        public int ImageId { get; set; }
    }
}
