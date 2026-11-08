using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MailRu.Marusia.Models
{
    internal sealed class StateJsonConverter : JsonConverter<State>
    {
        private static readonly ObjectValueJsonConverter ValueConverter = new ObjectValueJsonConverter();

        public override State Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            var state = new State();
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return state;
                }

                var key = reader.GetString();
                if (!reader.Read())
                {
                    break;
                }

                state[key] = ValueConverter.Read(ref reader, typeof(object), options);
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, State value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            foreach (var entry in value)
            {
                writer.WritePropertyName(entry.Key);
                ValueConverter.Write(writer, entry.Value, options);
            }

            writer.WriteEndObject();
        }
    }
}
