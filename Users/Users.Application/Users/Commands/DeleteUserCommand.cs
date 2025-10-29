using Users.Application.Abstractions;
using Users.Application.Abstractions.Messaging;
using Users.Domain;
using Users.Domain.Entities;

namespace Users.Application.Users.Commands;
public sealed record DeleteUserCommand(
    Guid Id
) : ICommand<User>;

public sealed class DeleteUserCommandHandler(
    IUserRepository repository
) : ICommandHandler<DeleteUserCommand, User>
{
    public async Task<Result<User>> HandleAsync(DeleteUserCommand commnad, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(commnad.Id.ToString());

        var searchUser = await repository.GetById(commnad.Id);

        if (searchUser == null)
            return Result<User>.Failure("No ha sido posible encontrar la entidad");

        var userUpdated = searchUser.Data;
        userUpdated!.IsActive = false;

        return Result<User>.Success(userUpdated, "Operación realizada con éxito");
        throw new NotImplementedException();
    }
}