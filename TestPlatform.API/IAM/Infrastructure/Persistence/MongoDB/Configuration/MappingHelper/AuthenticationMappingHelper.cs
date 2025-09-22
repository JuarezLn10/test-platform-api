using MongoDB.Bson.Serialization;
using TestPlatform.API.IAM.Domain.Model.ValueObjects;
using TestPlatform.API.IAM.Infrastructure.Persistence.MongoDB.Configuration.Mapping;
using TestPlatform.API.Shared.Infrastructure.Persistence.MongoDB.Configuration.Helpers;

namespace TestPlatform.API.IAM.Infrastructure.Persistence.MongoDB.Configuration.MappingHelper;

public static class AuthenticationMappingHelper
{
    /// <summary>
    ///     This method registers all shared MongoDB mappings.
    ///     It should be called once during the application startup.
    /// </summary>
    public static void RegisterAuthenticationMappings()
    {
        // Use of EUserRoles Value Object serializer
        MongoSerializerRegistrationHelper.TryRegisterSerializer(new UserRolesSerializer());
    }
}