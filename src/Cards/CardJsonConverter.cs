using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace MailRu.Marusia.Models.Cards
{
    internal sealed class CardJsonConverter : JsonConverter<ICard>
    {
        private static readonly ConditionalWeakTable<JsonSerializerOptions, JsonSerializerOptions> CustomCardOptions =
            new ConditionalWeakTable<JsonSerializerOptions, JsonSerializerOptions>();

        public override ICard Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotSupportedException("Deserialize a card using its concrete type.");
        }

        public override void Write(Utf8JsonWriter writer, ICard value, JsonSerializerOptions options)
        {
            var type = value.GetType();
            if (type.Assembly != typeof(ICard).Assembly)
            {
                options = CustomCardOptions.GetValue(options, CreateCustomCardOptions);
            }

            JsonSerializer.Serialize(writer, value, type, options);
        }

        private static JsonSerializerOptions CreateCustomCardOptions(JsonSerializerOptions options)
        {
            return new JsonSerializerOptions(options)
            {
                TypeInfoResolver = (options.TypeInfoResolver ?? new DefaultJsonTypeInfoResolver())
                    .WithAddedModifier(ApplyCardPropertyNames)
            };
        }

        private static void ApplyCardPropertyNames(JsonTypeInfo typeInfo)
        {
            if (typeInfo.Type.Assembly == typeof(ICard).Assembly || !typeof(ICard).IsAssignableFrom(typeInfo.Type))
            {
                return;
            }

            foreach (var property in typeInfo.Properties)
            {
                if (property.AttributeProvider is MemberInfo member &&
                    !member.IsDefined(typeof(JsonPropertyNameAttribute), inherit: true))
                {
                    property.Name = JsonNamingPolicy.SnakeCaseLower.ConvertName(member.Name);
                }
            }
        }
    }
}
