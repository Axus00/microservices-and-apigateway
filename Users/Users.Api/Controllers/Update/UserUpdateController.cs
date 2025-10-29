using Microsoft.AspNetCore.Mvc;
using Users.Application.Abstractions.Messaging;
using Users.Application.Users.Commands;
using Users.Domain.Dtos;

namespace Users.Api.Controllers.Update;

[ApiController]
[Route($"api/{RestResources.Version}/{RestResources.Users}")]
public class UserUpdateController(ICommandHandler<UpdateUserCommand, UserDto> commandHandler) : ControllerBase
{
    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand updateUserCommand, CancellationToken cancellationToken = default)
    {
        var result = await commandHandler.HandleAsync(updateUserCommand, cancellationToken);
        return Ok(result.Data); 
    }
}
