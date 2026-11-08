using System;
using System.Globalization;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MailRu.Marusia.Models
{
    internal sealed class ObjectValueJsonConverter : JsonConverter<object>
    {
        public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.Null:
                    return null;
                case JsonTokenType.True:
                case JsonTokenType.False:
                    return reader.GetBoolean();
                case JsonTokenType.String:
                    var text = reader.GetString();
                    if (text.Length >= 19 && text[10] == 'T' && reader.TryGetDateTime(out var date))
                    {
                        return date;
                    }

                    return text;
                case JsonTokenType.Number:
                    if (reader.TryGetInt64(out var integer))
                    {
                        return integer;
                    }

                    using (var document = JsonDocument.ParseValue(ref reader))
                    {
                        var number = document.RootElement;
                        if (BigInteger.TryParse(number.GetRawText(), NumberStyles.AllowLeadingSign,
                            CultureInfo.InvariantCulture, out var largeInteger))
                        {
                            return largeInteger;
                        }

                        return number.GetDouble();
                    }

                case JsonTokenType.StartObject:
                case JsonTokenType.StartArray:
                    return JsonElement.ParseValue(ref reader);
                default:
                    throw new JsonException();
            }
        }

        public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
        {
            if (value is BigInteger integer)
            {
                writer.WriteRawValue(integer.ToString(CultureInfo.InvariantCulture));
                return;
            }

            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
