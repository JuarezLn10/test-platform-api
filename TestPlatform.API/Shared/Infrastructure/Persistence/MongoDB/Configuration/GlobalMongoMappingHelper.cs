using TestPlatform.API.Shared.Infrastructure.Persistence.MongoDB.Configuration.Helpers;
using TestPlatform.API.Shared.Infrastructure.Persistence.MongoDB.Configuration.MappingHelper;

namespace TestPlatform.API.Shared.Infrastructure.Persistence.MongoDB.Configuration;

/// <summary>
///     This class groups all MongoDB mapping helpers for different bounded contexts.
/// </summary>
public static class GlobalMongoMappingHelper
{
    private static bool _initialized = false;

    /// <summary>
    ///     Registers all MongoDB mappings for all bounded contexts.
    /// </summary>
    public static void RegisterAllBoundedContextMappings()
    {
        if (_initialized) return;
        
        // Shared Bounded Context
        SharedMappingHelper.RegisterSharedMappings();
        
        // IAM Bounded Context
        
        
        _initialized = true;
    }
}