using TestPlatform.API.IAM.Domain.Model.Aggregates;
using TestPlatform.API.IAM.Domain.Model.Queries;

namespace TestPlatform.API.IAM.Domain.Services;

/// <summary>
///     The interface for user query services.
/// </summary>
public interface IUserQueryService
{
    /// <summary>
    ///     Query handler for GetAllUsersQuery
    /// </summary>
    /// <param name="query">
    ///     The query object containing parameters for fetching all users.
    /// </param>
    /// <returns>
    ///     The list of users matching the query criteria.
    /// </returns>
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
    
    /// <summary>
    ///     Query handler for GetUserByIdQuery
    /// </summary>
    /// <param name="query">
    ///     The query object containing the user ID to fetch.
    /// </param>
    /// <returns>
    ///     The user with the specified ID, or null if not found.
    /// </returns>
    Task<User?> Handle(GetUserByIdQuery query);
}