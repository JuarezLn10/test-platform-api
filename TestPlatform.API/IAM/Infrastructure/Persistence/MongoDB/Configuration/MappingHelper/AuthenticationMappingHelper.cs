using MongoDB.Bson.Serialization;
using TestPlatform.API.IAM.Domain.Model.ValueObjects;
using TestPlatform.API.IAM.Infrastructure.Persistence.MongoDB.Configuration.Mapping;

namespace TestPlatform.API.IAM.Infrastructure.Persistence.MongoDB.Configuration.MappingHelper;

public static class AuthenticationMappingHelper
{
    private static bool _initialized = false;
    
    /// <summary>
    ///     This method registers all shared MongoDB mappings.
    ///     It should be called once during the application startup.
    /// </summary>
    public static void RegisterAuthenticationMappings()
    {
        if (_initialized) return;
        
        // Use of EUserRoles Value Object serializer
        if (!BsonSerializer.LookupSerializer<EUserRoles>().GetType().IsAssignableTo(typeof(UserRolesSerializer)))
        {
            BsonSerializer.RegisterSerializer(new UserRolesSerializer());
        }
        
        _initialized = true;
    }
}