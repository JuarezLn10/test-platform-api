using MongoDB.Driver;
using TestPlatform.API.Shared.Infrastructure.Persistence.MongoDB.Configuration.Extensions;

namespace TestPlatform.API.Shared.Infrastructure.Persistence.MongoDB.Configuration.Helpers;

/// <summary>
///     Convention Pack extensions
/// </summary>
/// <remarks>
///     It includes a method to use the camel case naming convention for fields according to an object type.
/// </remarks>
public static class MongoCollectionNamingHelper
{
    /// <summary>
    ///     Use camel case naming convention
    /// </summary>
    /// <remarks>
    ///     This method sets the naming convention for the database collections to camel case.
    /// </remarks>
    public static IMongoCollection<T> GetCollectionWithConvention<T>(this IMongoDatabase database)
    {
        // Base name of the type T
        var baseName = typeof(T).Name;

        // Applies pluralization and camel case conversion to the collection name
        var collectionName = baseName.ToPlural().ToSnakeCase();

        // Returns the collection with the modified name
        return database.GetCollection<T>(collectionName);
    }
}