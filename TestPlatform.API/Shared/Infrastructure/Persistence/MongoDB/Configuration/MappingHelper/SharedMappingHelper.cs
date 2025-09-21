using MongoDB.Bson.Serialization;
using TestPlatform.API.Shared.Domain.Model.ValueObjects;
using TestPlatform.API.Shared.Infrastructure.Persistence.MongoDB.Configuration.Mapping;

namespace TestPlatform.API.Shared.Infrastructure.Persistence.MongoDB.Configuration.MappingHelper;

/// <summary>
///     This class provides helper methods for MongoDB mapping configurations.
///     It allows the mapping for value objects that are used inside a class.
/// </summary>
public static class SharedMappingHelper
{
    private static bool _initialized = false;
    
    /// <summary>
    ///     This method registers all shared MongoDB mappings.
    ///     It should be called once during the application startup.
    /// </summary>
    public static void RegisterSharedMappings()
    {
        if (_initialized) return;
        
        // Use of Email Value Object serializer
        if (!BsonSerializer.LookupSerializer<Email>().GetType().IsAssignableTo(typeof(EmailSerializer)))
        {
            BsonSerializer.RegisterSerializer(new EmailSerializer());
        }
        
        // Use of AccountId Value Object serializer
        if (!BsonSerializer.LookupSerializer<AccountId>().GetType().IsAssignableTo(typeof(AccountIdSerializer)))
        {
            BsonSerializer.RegisterSerializer(new AccountIdSerializer());
        }
        
        _initialized = true;
    }
}