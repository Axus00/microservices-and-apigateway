using Users.Application.Abstractions;
using Users.Application.Abstractions.Messaging;
using Users.Domain;
using Users.Domain.Dtos;
using Users.Domain.Entities;

namespace Users.Application.Products.commands;
public sealed record CreateProductCommand(
    string Name,
    string Description
) : ICommand<Product>;

public sealed class CreateProductCommandHandler(
    IProductRepository repository
) : ICommandHandler<CreateProductCommand, Product>
{
    public async Task<Result<Product>> HandleAsync(CreateProductCommand commnad, CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await repository.CreateAsync(commnad, dto => new Product
            {
                Name = commnad.Name,
                Description = commnad.Description,
                IsAvalable = true,

            });

            if (result == null)
                return Result<Product>.Failure("No ha sido posible crear el producto");

            if (!result.IsSuccess)
                return Result<Product>.Failure(result.Message!);

            return Result<Product>.Success(result.Data!, "Operación realizada con éxito");
        }
        catch (ArgumentException ex)
        {
            return Result<Product>.Failure($"Error: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            return Result<Product>.Failure($"Operación inválida: {ex.Message}");
        }
    }
}