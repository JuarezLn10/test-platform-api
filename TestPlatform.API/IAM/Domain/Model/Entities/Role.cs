using MongoDB.Bson;
using TestPlatform.API.IAM.Domain.Model.ValueObjects;
using TestPlatform.API.Shared.Domain.Model.ValueObjects;

namespace TestPlatform.API.IAM.Domain.Model.Entities;

/// <summary>
///     This class represents a role entity in the system.
/// </summary>
public class Role : IEntity
{
    /// <summary>
    ///     The unique identifier for the role.
    /// </summary>
    public ObjectId Id { get; } = ObjectId.GenerateNewId();
    
    /// <summary>
    ///     The name of the role.
    /// </summary>
    public EUserRoles Name { get; private set; }
}