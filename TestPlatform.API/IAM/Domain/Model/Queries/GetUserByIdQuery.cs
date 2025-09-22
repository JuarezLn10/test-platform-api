using MongoDB.Bson;

namespace TestPlatform.API.IAM.Domain.Model.Queries;

/// <summary>
///     Query to get a user by their unique identifier.
/// </summary>
public record GetUserByIdQuery(string UserId);