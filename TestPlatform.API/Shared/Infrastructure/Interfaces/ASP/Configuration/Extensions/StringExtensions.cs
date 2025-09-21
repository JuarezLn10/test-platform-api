using System.Text.RegularExpressions;

namespace TestPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;

/// <summary>
///     This class provides extension methods for string manipulation.
/// </summary>
public static partial class StringExtensions
{
    /// <summary>
    ///     Transforms a given string into kebab-case format.
    /// </summary>
    /// <param name="text">
    ///     The input string to be transformed.
    /// </param>
    /// <returns>
    ///     The transformed string in kebab-case format.
    /// </returns>
    public static string ToKebabCase(this string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return text;
        }

        return KebabCaseRegex().Replace(text, "-$1")
            .Trim()
            .ToLower();
    }

    /// <summary>
    ///     This method defines a compiled regular expression to identify the positions in a string where a lowercase letter is followed by an uppercase letter or where an uppercase letter is followed by a lowercase letter, excluding the start of the string.
    /// </summary>
    /// <returns>
    ///     The compiled regular expression.
    /// </returns>
    [GeneratedRegex("(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", RegexOptions.Compiled)]
    private static partial Regex KebabCaseRegex();
}