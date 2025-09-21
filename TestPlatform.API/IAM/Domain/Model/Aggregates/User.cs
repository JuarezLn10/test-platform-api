using MongoDB.Bson;
using TestPlatform.API.Shared.Domain.Model.ValueObjects;

namespace TestPlatform.API.IAM.Domain.Model.Aggregates;

/// <summary>
/// This class represents a user entity in the system.
/// </summary>
public class User : IEntity
{
    public ObjectId Id { get; } = ObjectId.GenerateNewId();
    
    
}