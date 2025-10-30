using Microsoft.AspNetCore.Mvc;
using Users.Application.Abstractions.Messaging;
using Users.Application.Products.Queries;
using Users.Domain.Dtos;

namespace Users.Api.Controllers.Get;

[ApiController]
[Route($"api/{RestResources.Version}/{RestResources.Products}")]
public class ProductController(IQueryHandler<GetProductQuery, ProductDto> queryHandler) : ControllerBase
{
    [HttpGet("id:guid")]
    public async Task<IActionResult> GetProduct(Guid Id, CancellationToken cancellationToken)
    {
        var query = new GetProductQuery(Id);
        var result = await queryHandler.HandleAsync(query, cancellationToken);
        return Ok(result);
    }
}
