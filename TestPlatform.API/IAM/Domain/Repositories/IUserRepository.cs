using TestPlatform.API.IAM.Domain.Model.Aggregates;
using TestPlatform.API.Shared.Domain.Model.ValueObjects;
using TestPlatform.API.Shared.Domain.Repositories;

namespace TestPlatform.API.IAM.Domain.Repositories;

/// <summary>
///     Repository interface for managing User entities.
/// </summary>
public interface IUserRepository : IBaseRepository<User>
{
    /// <summary>
    ///     Method to check if a user exists by their email.
    /// </summary>
    /// <param name="email">
    ///     The email address to check for existence.
    /// </param>
    /// <returns>
    ///     True if a user with the specified email exists; otherwise, false.
    /// </returns>
    Task<bool> ExistsByEmailAsync(Email email);
}