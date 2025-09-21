using TestPlatform.API.IAM.Domain.Model.Aggregates;
using TestPlatform.API.IAM.Domain.Model.Commands;

namespace TestPlatform.API.IAM.Domain.Services;

/// <summary>
///     Service for handling user-related commands.
/// </summary>
public interface IUserCommandService
{
    /// <summary>
    ///     Command handler for creating a new user.
    /// </summary>
    /// <param name="command">
    ///     The command containing the details for the user to be created.
    /// </param>
    /// <returns>
    ///     The created user, or null if the creation failed.
    /// </returns>
    Task<User?> Handle(CreateUserCommand command);
}