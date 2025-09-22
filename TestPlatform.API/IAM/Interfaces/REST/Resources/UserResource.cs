namespace TestPlatform.API.IAM.Interfaces.REST.Resources;

/// <summary>
///     Resource class to define which data of a user should be exposed via the REST API.
/// </summary>
public record UserResource(
        string Id,
        string Username
    );