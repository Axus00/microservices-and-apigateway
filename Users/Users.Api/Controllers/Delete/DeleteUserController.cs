using Microsoft.AspNetCore.Mvc;
using Users.Application.Abstractions.Messaging;
using Users.Application.Users.Commands;
using Users.Domain.Entities;

namespace Users.Api.Controllers.Delete;

[ApiController]
[Route($"api/{RestResources.Version}/{RestResources.Users}")]
public class DeleteUserController(ICommandHandler<DeleteUserCommand, User> commandHandler) : ControllerBase
{
    [HttpDelete("id:guid")]
    public async Task<IActionResult> DeleteUser(Guid Id, CancellationToken cancellationToken)
    {
        var query = new DeleteUserCommand(Id);
        var result = await commandHandler.HandleAsync(query, cancellationToken);
        return Ok(result.Data);
    }
}
