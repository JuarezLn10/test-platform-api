using TestPlatform.API.Shared.Domain.Model.ValueObjects;

namespace TestPlatform.API.IAM.Domain.Model.Commands;

/// <summary>
///     This record represents a command to create a new user.
/// </summary>
public record CreateUserCommand(Email UserName, string Password);