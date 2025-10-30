using Microsoft.AspNetCore.Mvc;
using Users.Application.Abstractions.Messaging;
using Users.Application.Users.Queries;
using Users.Domain.Entities;

namespace Users.Api.Controllers.Get;

[ApiController]
[Route($"api/{RestResources.Version}/{RestResources.Users}")]
public sealed class UsersController(IQueryHandler<GetUsersQuery, List<User>> queryHandler) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetUsers(CancellationToken cancellationToken = default)
    {
        var query = new GetUsersQuery();
        var result = await queryHandler.HandleAsync(query, cancellationToken);
        return Ok(result);
    }
}