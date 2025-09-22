using System.Text.Json;
using System.Text.Json.Serialization;
using TestPlatform.API.Shared.Domain.Model.ValueObjects;

namespace TestPlatform.API.Shared.Infrastructure.Converters.JSON;

public class EmailJsonConverter : JsonConverter<Email>
{
    public override Email Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return new Email(value);
    }

    public override void Write(Utf8JsonWriter writer, Email value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.GetValue);
    }
}
