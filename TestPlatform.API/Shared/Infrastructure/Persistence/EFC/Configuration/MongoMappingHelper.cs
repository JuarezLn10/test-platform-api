using MongoDB.Bson.Serialization;
using TestPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace TestPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
///     First option for mapping classes to MongoDB collections with camelCase and pluralized names
///     This is an alternative to using ConventionPackExtensions
///     It provides a method to register class maps with camelCase and pluralized names
///     It can be used in the application startup to register all necessary class maps
/// </summary>
public static class MongoMappingHelper
{
    /// <summary>
    ///     This method registers a class map for the specified type T
    /// </summary>
    /// <typeparam name="T">
    ///     The type of the class to register
    /// </typeparam>
    public static void RegisterClassMapWithCamelCase<T>()
    {
        if (!BsonClassMap.IsClassMapRegistered(typeof(T)))
        {
            BsonClassMap.RegisterClassMap<T>(cm =>
            {
                cm.AutoMap();

                // Pluralizar y camelCase para nombre de clase, útil si usas esto para obtener colecciones
                var collectionName = typeof(T).Name.ToPlural().ToCamelCase();

                // Cambiar el nombre de la clase en el mapeo (no es obligatorio, pero puede ayudar)
                cm.SetDiscriminator(collectionName);

                // Ahora, para cada propiedad, asignar nombre camelCase
                foreach (var memberMap in cm.AllMemberMaps)
                {
                    var propName = memberMap.MemberName;
                    memberMap.SetElementName(propName.ToCamelCase());
                }
            });
        }
    }
}