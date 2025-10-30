using Users.Application.Abstractions;
using Users.Application.Abstractions.Messaging;
using Users.Domain;
using Users.Domain.Dtos;
using Users.Domain.Entities;

namespace Users.Application.Users.Commands;
public sealed record UpdateUserCommand(
    Guid Id,
    string Name,
    string LastName,
    string Email,
    string Phone
) : ICommand<UserDto>;

public sealed class UpdatedUserCommandHandler(
    IUserRepository repository
) : ICommandHandler<UpdateUserCommand, UserDto>
{
    public async Task<Result<UserDto>> HandleAsync(UpdateUserCommand commnad, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(commnad);

        var searchUser = await repository.GetByIdAsync(commnad.Id);

        if (!searchUser.IsSuccess)
            return Result<UserDto>.Failure("No ha sido posible encontrar la entidad");

        //Mapeamos
        var user = searchUser.Data;
        user!.Name = commnad.Name;
        user!.LastName = commnad.LastName;
        user!.Email = commnad.Email;
        user!.Phone = commnad.Phone;

        var userUpdated = await repository.UpdateAsync(commnad.Id, user);

        if (!userUpdated.IsSuccess)
            return Result<UserDto>.Failure("No ha sido posible actualziar la entidad");

        return Result<UserDto>.Success(new UserDto
        {
            Name = userUpdated.Data!.Name,
            LastName = userUpdated.Data!.LastName,
            Email = userUpdated.Data!.Email,
            Phone = userUpdated.Data!.Phone
        }, "Operación realizada con éxito");
    }
}