namespace TestPlatform.API.Shared.Domain.Model.ValueObjects;

/// <summary>
/// This record class serves as a Value Object for an identifier for the Account aggregate.
/// </summary>
public record AccountId()
{
    /// <summary>
    /// This is the value of the AccountId Value Object.
    /// </summary>
    private string Id { get; } = string.Empty;

    /// <summary>
    /// Default constructor for the AccountId Value Object.
    /// It is used to validate if the provided id is a non-empty string.
    /// </summary>
    /// <param name="id"> The identifier for the account </param>
    /// <exception cref="ArgumentException">Account ID must be a non-empty string.</exception>
    public AccountId(string id) : this()
    {
        if (id == null || id.Trim().Length == 0)
        {
            throw new ArgumentException("Account ID must be a non-empty string.");
        }
        
        Id = id;
    }
}