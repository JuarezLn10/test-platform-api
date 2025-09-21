using MongoDB.Bson;

namespace TestPlatform.API.Shared.Domain.Model.ValueObjects;

public interface IEntity
{
    ObjectId Id { get; set; }
}