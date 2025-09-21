using MongoDB.Bson.Serialization.Conventions;

namespace TestPlatform.API.Shared.Infrastructure.Persistence.MongoDB.Configuration.Helpers;

/// <summary>
///     Convention Pack extensions
/// </summary>
/// <remarks>
///     This class contains extension methods for the convention pack for MongoDB.
///     It includes a method to use the camel case and/or plural naming convention according to an object type.
///     It also pluralizes the collection names.
/// </remarks>
public static class MongoFieldNamingHelper
{
    /// <summary>
    ///     Creates a new convention pack with camel case naming convention for fields.
    /// </summary>
    /// <remarks>
    ///     This method creates the convention pack and registers it in the convention registry.
    ///     It applies the camel case naming convention to all classes.
    ///     It helps to reduce the boilerplate code when working with MongoDB (e.g., avoiding the need to use [BsonElement("camelCaseName")] attributes).
    /// </remarks>
    public static void UseCamelCaseNamingConvention()
    {
        var conventionPack = new ConventionPack
        {
            new CamelCaseElementNameConvention()
        };

        ConventionRegistry.Register(
            "CamelCase Convention",
            conventionPack,
            t => true); // Aplica a todas las clases
    }
}