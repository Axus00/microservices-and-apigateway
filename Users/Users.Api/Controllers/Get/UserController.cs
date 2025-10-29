using Microsoft.AspNetCore.Mvc;
using Users.Application.Abstractions.Messaging;
using Users.Application.Users.Queries;
using Users.Domain.Dtos;
using Users.Domain.Entities;

namespace Users.Api.Controllers.Get;

[ApiController]
[Route($"api/{RestResources.Version}/{RestResources.Users}")]
public class UserController(IQueryHandler<GetUserQuery, UserDto> queryHandler) : ControllerBase
{
    [HttpGet("id:guid")]
    public async Task<IActionResult> GetUser(Guid id, CancellationToken cancellationToken = default)
    {
        var query = new GetUserQuery(id);
        var result = await queryHandler.HandleAsync(query, cancellationToken);
        return Ok(result);
    }
}
