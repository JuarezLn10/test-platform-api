using MongoDB.Bson.Serialization;
using TestPlatform.API.Shared.Domain.Model.ValueObjects;
using TestPlatform.API.Shared.Infrastructure.Persistence.MongoDB.Configuration.Helpers;
using TestPlatform.API.Shared.Infrastructure.Persistence.MongoDB.Configuration.Mapping;

namespace TestPlatform.API.Shared.Infrastructure.Persistence.MongoDB.Configuration.MappingHelper;

/// <summary>
///     This class provides helper methods for MongoDB mapping configurations.
///     It allows the mapping for value objects that are used inside a class.
/// </summary>
public static class SharedMappingHelper
{
    /// <summary>
    ///     This method registers all shared MongoDB mappings.
    ///     It should be called once during the application startup.
    /// </summary>
    public static void RegisterSharedMappings()
    {
        // Use of Email Value Object serializer
        MongoSerializerRegistrationHelper.TryRegisterSerializer(new EmailSerializer());
        
        // Use of AccountId Value Object serializer
        MongoSerializerRegistrationHelper.TryRegisterSerializer(new AccountIdSerializer());
    }
}