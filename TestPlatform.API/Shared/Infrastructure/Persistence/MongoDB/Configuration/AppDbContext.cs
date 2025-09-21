using MongoDB.Driver;
using TestPlatform.API.Shared.Infrastructure.Persistence.MongoDB.Configuration.Helpers;

namespace TestPlatform.API.Shared.Infrastructure.Persistence.MongoDB.Configuration;

/// <summary>
///     Application database context.
/// </summary>
public class AppDbContext
{
    // MongoDB database instance
    private readonly IMongoDatabase _database;

    // Constructor to initialize the database context with MongoDB client and configuration
    public AppDbContext(IMongoClient client, IConfiguration config)
    {
        var databaseName = config["MongoDB:DatabaseName"];
        _database = client.GetDatabase(databaseName);
    }
    
    // To access any collection with the conventions applied
    public IMongoCollection<T> GetCollection<T>() =>
        _database.GetCollectionWithConvention<T>();
}