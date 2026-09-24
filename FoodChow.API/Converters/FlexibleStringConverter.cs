using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FoodChow.API.Converters
{
    public class FlexibleStringConverter : JsonConverter<string?>
    {
        public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                    return reader.GetString();

                case JsonTokenType.Number:
                    if (reader.TryGetInt64(out var longValue))
                        return longValue.ToString(CultureInfo.InvariantCulture);
                    if (reader.TryGetDouble(out var doubleValue))
                        return doubleValue.ToString(CultureInfo.InvariantCulture);
                    return reader.GetDecimal().ToString(CultureInfo.InvariantCulture);

                case JsonTokenType.True:
                    return "true";

                case JsonTokenType.False:
                    return "false";

                case JsonTokenType.Null:
                    return null;

                default:
                    throw new JsonException($"Unexpected token '{reader.TokenType}' while reading string value.");
            }
        }

        public override void Write(Utf8JsonWriter writer, string? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value);
        }
    }
}