namespace TestPlatform.API.Shared.Domain.Model.ValueObjects;

/// <summary>
/// This record class serves as a Value Object for an email address.
/// </summary>
public partial record Email()
{
    /// <summary>
    /// This is the value of the Email Value Object.
    /// </summary>
    private string Value { get; } = string.Empty;
    
    /// <summary>
    /// Default constructor for the Email Value Object.
    /// It is used to validate if the provided value is a non-empty string and follows a basic email format.
    /// </summary>
    /// <param name="value">The value pf the email</param>
    /// <exception cref="ArgumentException">
    /// Email must be a non-empty string.
    /// </exception>
    public Email(string value) : this()
    {
        if (value == null || value.Trim().Length == 0)
        {
            throw new ArgumentException("Email must be a non-empty string.");
        }

        // Simple email format validation
        if (!MyRegex().IsMatch(value))
        {
            throw new ArgumentException("Invalid email format.");
        }

        Value = value;
    }

    /// <summary>
    /// Defines a regex for basic email validation.
    /// </summary>
    /// <returns>
    /// Regex that matches a basic email format.
    /// </returns>
    [System.Text.RegularExpressions.GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
    private static partial System.Text.RegularExpressions.Regex MyRegex();
}