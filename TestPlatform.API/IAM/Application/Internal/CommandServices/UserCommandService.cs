using TestPlatform.API.IAM.Domain.Model.Aggregates;
using TestPlatform.API.IAM.Domain.Model.Commands;
using TestPlatform.API.IAM.Domain.Repositories;
using TestPlatform.API.IAM.Domain.Services;
using TestPlatform.API.Shared.Domain.Model.ValueObjects;

namespace TestPlatform.API.IAM.Application.Internal.CommandServices;

/// <summary>
///     Implements user-related command operations.
/// </summary>
public class UserCommandService(
        IUserRepository userRepository
    ) : IUserCommandService
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
    public async Task<User?> Handle(CreateUserCommand command)
    {
        // Verifies that the username is not already taken.
        if (await userRepository.ExistsByEmailAsync(command.UserName))
        {
            throw new ArgumentException($"User with username: {command.UserName.GetValue} tried to create a new account, but that username is already taken.");
        }

        // Creates the user with the command
        var user = new User(command);
        
        // Persists the new user in the database
        await userRepository.AddAsync(user);

        // Returns the created user
        return user;
    }
}