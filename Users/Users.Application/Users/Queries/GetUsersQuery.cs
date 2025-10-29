using Users.Application.Abstractions;
using Users.Application.Abstractions.Messaging;
using Users.Domain;
using Users.Domain.Entities;

namespace Users.Application.Users.Queries;
public sealed record GetUsersQuery() : IQuery<List<User>>;

internal sealed class GetUsersQueryHandler(
    IUserRepository repository
) : IQueryHandler<GetUsersQuery, List<User>>
{
    public async Task<Result<List<User>>> HandleAsync(GetUsersQuery query, CancellationToken cancellationToken = default)
    {
        var result = await repository.GetAll();

        if (!result.IsSuccess)
            return Result<List<User>>.Failure(result.Message!);

        return Result<List<User>>.Success(result.Data!, "Operación realizada con éxito");
    }
}
