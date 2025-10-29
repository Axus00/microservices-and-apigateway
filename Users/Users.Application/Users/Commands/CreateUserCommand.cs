using Users.Application.Abstractions;
using Users.Application.Abstractions.Messaging;
using Users.Domain;
using Users.Domain.Entities;

namespace Users.Application.Users.Commands;
public record CreateUserCommand(
    string Name,
    string LastName,
    string Email,
    string Phone,
    int Age
) : ICommand<User>;

internal sealed class CreateUserCommandHandler(
    IUserRepository repository
) : ICommandHandler<CreateUserCommand, User>
{
    public async Task<Result<User>> HandleAsync(CreateUserCommand commnad, CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await repository.CreateUser(commnad, dto => new User
            {
                Name = commnad.Name,
                LastName = commnad.LastName,
                Age = commnad.Age,
                Email = commnad.Email,
                Phone = commnad.Phone
            });

            if (result == null)
                return Result<User>.Failure("No ha sido posible crear el usuario");

            if (!result.IsSuccess)
                return Result<User>.Failure(result.Message!);

            return Result<User>.Success(result.Data!, "Usuario creado exitosamente");
        }
        catch (ArgumentException ex)
        {
            return Result<User>.Failure($"Error: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            return Result<User>.Failure($"Operación inválida: {ex.Message}");
        }
    }
}
