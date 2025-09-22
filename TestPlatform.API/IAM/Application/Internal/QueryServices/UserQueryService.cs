using TestPlatform.API.IAM.Domain.Model.Aggregates;
using TestPlatform.API.IAM.Domain.Model.Queries;
using TestPlatform.API.IAM.Domain.Repositories;
using TestPlatform.API.IAM.Domain.Services;

namespace TestPlatform.API.IAM.Application.Internal.QueryServices;

/// <summary>
///     Implements user-related query operations.
/// </summary>
public class UserQueryService(
        IUserRepository userRepository
    ) : IUserQueryService
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
    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        return await userRepository.GetAllAsync();
    }

    /// <summary>
    ///     Query handler for GetUserByIdQuery
    /// </summary>
    /// <param name="query">
    ///     The query object containing the user ID to fetch.
    /// </param>
    /// <returns>
    ///     The user with the specified ID, or null if not found.
    /// </returns>
    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.UserId);
    }
}