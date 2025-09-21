using Humanizer;

namespace TestPlatform.API.Shared.Infrastructure.Persistence.MongoDB.Configuration.Extensions;

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
    ///     Convert a string to snake case
    /// </summary>
    /// <param name="text">The string to convert</param>
    /// <returns>The string converted to snake case</returns>
    public static string ToSnakeCase(this string text)
    {
        return new string(Convert(text.GetEnumerator()).ToArray());

        static IEnumerable<char> Convert(CharEnumerator e)
        {
            if (!e.MoveNext()) yield break;

            yield return char.ToLower(e.Current);

            while (e.MoveNext())
                if (char.IsUpper(e.Current))
                {
                    yield return '_';
                    yield return char.ToLower(e.Current);
                }
                else
                {
                    yield return e.Current;
                }
        }
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