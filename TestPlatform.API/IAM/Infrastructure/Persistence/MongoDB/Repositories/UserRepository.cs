using MongoDB.Driver;
using TestPlatform.API.IAM.Domain.Model.Aggregates;
using TestPlatform.API.IAM.Domain.Repositories;
using TestPlatform.API.Shared.Domain.Model.ValueObjects;
using TestPlatform.API.Shared.Infrastructure.Persistence.MongoDB.Configuration;
using TestPlatform.API.Shared.Infrastructure.Persistence.MongoDB.Repositories;

namespace TestPlatform.API.IAM.Infrastructure.Persistence.MongoDB.Repositories;

/// <summary>
///     Interface implementation for User repository
/// </summary>
/// <param name="context">
///     The MongoDB context to be used for database operations
/// </param>
public class UserRepository (AppDbContext context) : BaseRepository<User>(context), IUserRepository
{
    /// <summary>
    ///    The MongoDB collection for the entity type T
    /// </summary>
    private readonly IMongoCollection<User> _collection = context.GetCollection<User>();
    
    /// <summary>
    ///     Method to check if a user exists by their email.
    /// </summary>
    /// <param name="email">
    ///     The email address to check for existence.
    /// </param>
    /// <returns>
    ///     True if a user with the specified email exists; otherwise, false.
    /// </returns>
    public async Task<bool> ExistsByEmailAsync(Email email)
    {
        return await _collection.Find(x => x.UserName == email).AnyAsync();
    }
}