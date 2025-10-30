using Microsoft.AspNetCore.Mvc;
using Users.Application.Abstractions.Messaging;
using Users.Application.Products.commands;
using Users.Domain.Entities;

namespace Users.Api.Controllers.Post;

[ApiController]
[Route($"api/{RestResources.Version}/{RestResources.Products}")]
public class ProductCreateController(ICommandHandler<CreateProductCommand, Product> commandHandler) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var result = await commandHandler.HandleAsync(command, cancellationToken);
        return Ok(result);
    }
}
