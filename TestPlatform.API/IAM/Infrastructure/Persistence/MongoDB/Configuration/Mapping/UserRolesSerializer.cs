using Microsoft.OpenApi.Extensions;
using MongoDB.Bson.Serialization;
using TestPlatform.API.IAM.Domain.Model.ValueObjects;

namespace TestPlatform.API.IAM.Infrastructure.Persistence.MongoDB.Configuration.Mapping;

public class UserRolesSerializer : IBsonSerializer<EUserRoles>
{
    public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, EUserRoles value)
    {
        context.Writer.WriteString(value.ToString());
    }

    public EUserRoles Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var value = context.Reader.ReadString(); // e.g., "Admin"
        return Enum.Parse<EUserRoles>(value, ignoreCase: true);
    }

    void IBsonSerializer.Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        => Serialize(context, args, (EUserRoles)value);

    object IBsonSerializer.Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        => Deserialize(context, args);
 
    public Type ValueType => typeof(EUserRoles);
}