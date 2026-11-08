using Newtonsoft.Json;

namespace MailRu.Marusia.Models.Tests;

internal static class SdkJson
{
    public static T Read<T>(string json) => JsonConvert.DeserializeObject<T>(json);

    public static string Write<T>(T value) => JsonConvert.SerializeObject(value);
}
