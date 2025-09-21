using Humanizer;

namespace TestPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

/// <summary>
///     String extensions
/// </summary>
/// <remarks>
///     This class contains extension methods for strings.
///     It includes methods to convert strings to camel case and pluralize them.
/// </remarks>
public static class StringExtensions
{
    /// <summary>
    ///     Convert a string to camel case
    /// </summary>
    /// <param name="text">The string to convert</param>
    /// <returns>The string converted to camel casea</returns>
    public static string ToCamelCase(this string text)
    {
        if (string.IsNullOrEmpty(text) || char.IsLower(text[0]))
            return text;

        return char.ToLowerInvariant(text[0]) + text[1..];
    }

    /// <summary>
    ///     Pluralize a string
    /// </summary>
    /// <param name="text">The string to convert</param>
    /// <returns>The string converted to plural</returns>
    public static string ToPlural(this string text)
    {
        return text.Pluralize(false);
    }
}