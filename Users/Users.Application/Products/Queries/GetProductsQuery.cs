using Users.Application.Abstractions;
using Users.Application.Abstractions.Messaging;
using Users.Domain;
using Users.Domain.Entities;

namespace Users.Application.Products.Queries;
public sealed record GetProductsQuery(

) : IQuery<List<Product>>;

public sealed class GetProductsQueryHandler(
    IProductRepository repository
) : IQueryHandler<GetProductsQuery, List<Product>>
{
    public async Task<Result<List<Product>>> HandleAsync(GetProductsQuery query, CancellationToken cancellationToken = default)
    {
        var result = await repository.GetAllAsync();

        if (!result.IsSuccess)
            return Result<List<Product>>.Failure(result.Message!);

        return Result<List<Product>>.Success(result.Data!, "Operación realizada con éxito");
    }
}
