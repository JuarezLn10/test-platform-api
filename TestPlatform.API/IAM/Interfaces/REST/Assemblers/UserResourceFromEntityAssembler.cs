using TestPlatform.API.IAM.Domain.Model.Aggregates;
using TestPlatform.API.IAM.Interfaces.REST.Resources;

namespace TestPlatform.API.IAM.Interfaces.REST.Assemblers;

/// <summary>
///     Static assembler class to convert User entity to UserResource.
/// </summary>
public static class UserResourceFromEntityAssembler
{
    /// <summary>
    ///     Transforms a User entity into a UserResource.
    /// </summary>
    /// <param name="entity">
    ///     The User entity to be transformed.
    /// </param>
    /// <returns>
    ///     The corresponding UserResource.
    /// </returns>
    public static UserResource ToResourceFromEntity(User entity)
    {
        return new UserResource(
                entity.Id.ToString(),
                entity.UserName.GetValue
            );
    }
}