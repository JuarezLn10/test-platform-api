using MongoDB.Bson.Serialization;
using TestPlatform.API.Shared.Domain.Model.ValueObjects;

namespace TestPlatform.API.Shared.Infrastructure.Persistence.MongoDB.Configuration.Mapping;

/// <summary>
///     This class provides a custom serializer for the Email value object to be used in MongoDB.
/// </summary>
public class EmailSerializer : IBsonSerializer<Email>
{
    public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Email value)
    {
        context.Writer.WriteString(value.GetValue);
    }

    public Email Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var value = context.Reader.ReadString();
        return new Email(value);
    }

    void IBsonSerializer.Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        => Serialize(context, args, (Email)value);

    object IBsonSerializer.Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        => Deserialize(context, args);
    
    public Type ValueType => typeof(Email);
}