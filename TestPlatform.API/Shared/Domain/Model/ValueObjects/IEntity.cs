using MongoDB.Bson;

namespace TestPlatform.API.Shared.Domain.Model.ValueObjects;

/// <summary>
/// This interface represents an entity with a unique identifier.
/// </summary>
public interface IEntity
{
    ObjectId Id { get; }
}