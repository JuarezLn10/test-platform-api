using TestPlatform.API.IAM.Domain.Model.Commands;
using TestPlatform.API.IAM.Interfaces.REST.Resources;
using TestPlatform.API.Shared.Domain.Model.ValueObjects;

namespace TestPlatform.API.IAM.Interfaces.REST.Assemblers;

/// <summary>
///     Static assembler class to convert CreateUserResource to CreateUserCommand
/// </summary>
public static class CreateUserCommandFromResourceAssembler
{
    /// <summary>
    ///     Transforms CreateUserResource to CreateUserCommand
    /// </summary>
    /// <param name="resource">
    ///     The CreateUserResource to be transformed
    /// </param>
    /// <returns>
    ///     The corresponding CreateUserCommand
    /// </returns>
    public static CreateUserCommand ToCommandFromResource(CreateUserResource resource)
    {
        return new CreateUserCommand(
                new Email(resource.UserName),
                resource.Password
            );
    }
}