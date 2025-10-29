using Microsoft.AspNetCore.Mvc;
using Users.Application.Abstractions.Messaging;
using Users.Application.Users.Commands;
using Users.Domain.Entities;

namespace Users.Api.Controllers.Post;

[ApiController]
[Route($"api/{RestResources.Version}/{RestResources.Users}")]
public sealed class UserCreateController(ICommandHandler<CreateUserCommand, User> commandHandler) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command, CancellationToken cancellationToken = default)
    {
        var result = await commandHandler.HandleAsync(command, cancellationToken);
        return Ok(result.Message);
    }
}
