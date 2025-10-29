using Users.Application.Abstractions;
using Users.Application.Abstractions.Messaging;
using Users.Domain;
using Users.Domain.Dtos;
using Users.Domain.Entities;

namespace Users.Application.Users.Queries;


public sealed record GetUserQuery(
    Guid Id
) : IQuery<UserDto>;

internal sealed class GetUserQueryHandler(
    IUserRepository repository
) : IQueryHandler<GetUserQuery, UserDto>
{
    public async Task<Result<UserDto>> HandleAsync(GetUserQuery query, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(query);

        var user = await repository.GetById(query.Id);

        if (user.Data == null)
            return Result<UserDto>.Failure("No ha sido posible encontrar e usuario");
        
        return Result<UserDto>.Success(new UserDto
        {
            Name = user.Data.Name,
            LastName = user.Data.LastName,
            Email = user.Data.Email,
            Phone = user.Data.Phone
        }, "Operación realziada con éxito");
    }
}