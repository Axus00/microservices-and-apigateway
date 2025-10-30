using Users.Application.Abstractions;
using Users.Application.Abstractions.Messaging;
using Users.Domain;
using Users.Domain.Dtos;

namespace Users.Application.Products.Queries;
public sealed record GetProductQuery(
    Guid Id
) : IQuery<ProductDto>;

public sealed class GetProductQueryHandler(
    IProductRepository repository
) : IQueryHandler<GetProductQuery, ProductDto>
{
    public async Task<Result<ProductDto>> HandleAsync(GetProductQuery query, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(query);

        var searchProduct = await repository.GetByIdAsync(query.Id);

        if (searchProduct.Data == null)
            return Result<ProductDto>.Failure("No se ha encontrado el producto");

        return Result<ProductDto>.Success(new ProductDto
        {
            Name = searchProduct.Data.Name,
            Description = searchProduct.Data.Description,
            IsAvalable = searchProduct.Data.IsAvalable
        }, "Operación realizada con éxito");
    }
}
