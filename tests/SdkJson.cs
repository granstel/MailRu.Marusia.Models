using System.Text.Json;

namespace MailRu.Marusia.Models.Tests;

internal static class SdkJson
{
    public static T Read<T>(string json) => JsonSerializer.Deserialize<T>(json);

    public static string Write<T>(T value) => JsonSerializer.Serialize(value);
}
