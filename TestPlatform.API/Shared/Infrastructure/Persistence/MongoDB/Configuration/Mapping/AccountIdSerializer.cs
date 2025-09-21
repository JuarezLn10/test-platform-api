using MongoDB.Bson.Serialization;
using TestPlatform.API.Shared.Domain.Model.ValueObjects;

namespace TestPlatform.API.Shared.Infrastructure.Persistence.MongoDB.Configuration.Mapping;

/// <summary>
///     This class provides a custom serializer for the AccountId value object to be used in MongoDB.
/// </summary>
public class AccountIdSerializer : IBsonSerializer<AccountId>
{
    public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, AccountId value)
    {
        context.Writer.WriteString(value.GetId);
    }

    public AccountId Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var value = context.Reader.ReadString();
        return new AccountId(value);
    }

    void IBsonSerializer.Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        => Serialize(context, args, (AccountId)value);

    object IBsonSerializer.Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        => Deserialize(context, args);

    public Type ValueType => typeof(AccountId);
}