using MongoDB.Bson;
using TestPlatform.API.Shared.Domain.Model.ValueObjects;

namespace TestPlatform.API.IAM.Domain.Model.Aggregates;

/// <summary>
/// This class represents a user entity in the system.
/// </summary>
public class User(Email userName, string password) : IEntity
{
    /// <summary>
    ///     The unique identifier for the user.
    /// </summary>
    public ObjectId Id { get; } = ObjectId.GenerateNewId();
    
    /// <summary>
    ///     The role ID associated with the user.
    /// </summary>
    public ObjectId RoleId { get; private set; }

    /// <summary>
    ///     The username (email) of the user.
    /// </summary>
    public Email UserName { get; private set; } = userName;

    /// <summary>
    ///     The password of the user.
    /// </summary>
    public string Password { get; private set; } = password;
    
    
}