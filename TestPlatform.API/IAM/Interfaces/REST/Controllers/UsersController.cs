using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TestPlatform.API.IAM.Domain.Model.Aggregates;
using TestPlatform.API.IAM.Domain.Model.Queries;
using TestPlatform.API.IAM.Domain.Services;
using TestPlatform.API.IAM.Interfaces.REST.Assemblers;
using TestPlatform.API.IAM.Interfaces.REST.Resources;

namespace TestPlatform.API.IAM.Interfaces.REST.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available endpoints for users.")]
public class UsersController(
        IUserCommandService userCommandService,
        IUserQueryService userQueryService
    ) : ControllerBase
{
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get user by ID.",
        Description = "Retrieves a user by their unique identifier.",
        OperationId = "GetUserById")]
    [SwaggerResponse(StatusCodes.Status200OK, "User retrieved successfully.", typeof(UserResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "User with given id could not be found.")]
    public async Task<IActionResult> GetUserById([FromRoute] string id)
    {
        var getUserByIdQuery = new GetUserByIdQuery(id);
        var user = await userQueryService.Handle(getUserByIdQuery);
        if (user is null) return NotFound("User with given id could not be found");
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return Ok(userResource);
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all users.",
        Description = "Retrieves a list of all users.",
        OperationId = "GetAllUsers")]
    [SwaggerResponse(StatusCodes.Status200OK, "Users retrieved successfully.", typeof(IEnumerable<UserResource>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "Users could not be retrieved.")]
    public async Task<IActionResult> GetAllUsers()
    {
        var getAllUsersQuery = new GetAllUsersQuery();
        var users = await userQueryService.Handle(getAllUsersQuery);
        var enumerable = users as User[] ?? users.ToArray();
        if (enumerable.Length == 0) return NotFound("Users could not be retrieved");
        var userResources = enumerable.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(userResources);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new user.",
        Description = "Creates a new user with the provided details.",
        OperationId = "CreateUser")]
    [SwaggerResponse(StatusCodes.Status201Created, "User created successfully.", typeof(UserResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input data.")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserResource resource)
    {
        var createUserCommand = CreateUserCommandFromResourceAssembler.ToCommandFromResource(resource);
        var user = await userCommandService.Handle(createUserCommand);
        if (user is null) return BadRequest("User could not be created");
        var userResource = UserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return CreatedAtAction(nameof(GetUserById), new { id = userResource.Id}, userResource);
    }
}