namespace TestPlatform.API.Shared.Domain.Repositories;

/// <summary>
///     Base repository interface for all repositories
/// </summary>
/// <remarks>
///     This interface defines the basic CRUD operations for all repositories
/// </remarks>
/// <typeparam name="TEntity">The Entity Type</typeparam>
public interface IBaseRepository<TEntity> where TEntity : class
{
    /// <summary>
    ///     Adds an entity to the repository
    /// </summary>
    /// <param name="entity">Entity object to add</param>
    Task AddAsync(TEntity entity);
    
    /// <summary>
    ///     Finds an entity by its id
    /// </summary>
    /// <param name="id">The Entity ID to Find</param>
    /// <returns>Entity object if found</returns>
    Task<TEntity?> FindByIdAsync(string id);
    
    /// <summary>
    ///     Updates the entity
    /// </summary>
    /// <param name="entity">The entity object to update</param>
    Task UpdateAsync(TEntity entity);
    
    /// <summary>
    ///     Removes the entity
    /// </summary>
    /// <param name="entity">The entity objects to remove</param>
    Task DeleteAsync(TEntity entity);
    
    /// <summary>
    ///     Get All entities
    /// </summary>
    /// <returns>An Enumerable containing all entity objects</returns>
    Task<IEnumerable<TEntity>> GetAllAsync();
}