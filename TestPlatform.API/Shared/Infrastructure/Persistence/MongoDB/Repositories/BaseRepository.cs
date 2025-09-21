using TestPlatform.API.Shared.Domain.Repositories;
using MongoDB.Driver;
using MongoDB.Bson;
using TestPlatform.API.Shared.Domain.Model.ValueObjects;
using TestPlatform.API.Shared.Infrastructure.Persistence.MongoDB.Configuration;

namespace TestPlatform.API.Shared.Infrastructure.Persistence.MongoDB.Repositories;

/// <summary>
///     Base repository for all repositories
/// </summary>
/// <remarks>
///     This class implements the basic CRUD operations for all repositories.
///     It requires the entity type to be passed as a generic parameter.
///     It also requires the context to be passed in the constructor.
/// </remarks>
public class BaseRepository<T>(AppDbContext context) : IBaseRepository<T> where T : IEntity
{
    /// <summary>
    ///     The MongoDB collection for the entity type T
    /// </summary>
    private readonly IMongoCollection<T> _collection = context.GetCollection<T>();

    /// <summary>
    ///     Adds an entity to the repository
    /// </summary>
    /// <param name="entity">Entity object to add</param>
    public async Task AddAsync(T entity)
    {
        await _collection.InsertOneAsync(entity);
    }

    /// <summary>
    ///     Finds an entity by its id
    /// </summary>
    /// <param name="id">The Entity ID to Find</param>
    /// <returns>Entity object if found</returns>
    public async Task<T?> FindByIdAsync(string id)
    {
        var objectId = ObjectId.Parse(id);
        return await _collection.Find(x => x.Id == objectId).FirstOrDefaultAsync();
    }

    /// <summary>
    ///     Updates the entity
    /// </summary>
    /// <param name="entity">The entity object to update</param>
    public async Task UpdateAsync(string id, T entity)
    {
        var objectId = ObjectId.Parse(id);
        await _collection.ReplaceOneAsync(x => x.Id == objectId, entity);
    }

    /// <summary>
    ///     Removes the entity
    /// </summary>
    /// <param name="id">The identifier of the entity to remove</param>
    public async Task DeleteAsync(string id)
    {
        var objectId = ObjectId.Parse(id);
        await _collection.DeleteOneAsync(x => x.Id == objectId);
    }

    /// <summary>
    ///     Get All entities
    /// </summary>
    /// <returns>An Enumerable containing all entity objects</returns>
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }
}
