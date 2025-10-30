using Microsoft.AspNetCore.Mvc;
using Users.Application.Abstractions.Messaging;
using Users.Application.Products.Queries;
using Users.Domain.Entities;

namespace Users.Api.Controllers.Get;

[ApiController]
[Route($"api/{RestResources.Version}/{RestResources.Products}")]
public class ProductsController(IQueryHandler<GetProductsQuery, List<Product>> queryHandler) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
    {
        var query = new GetProductsQuery();
        var result = await queryHandler.HandleAsync(query, cancellationToken);
        return Ok(result);
    }
}
