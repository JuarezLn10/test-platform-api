using TestPlatform.API.Shared.Domain.Model.ValueObjects;

namespace TestPlatform.API.IAM.Interfaces.REST.Resources;

/// <summary>
///     Resource for creating a new user
/// </summary>
public record CreateUserResource(
        string UserName,
        string Password
    );