using Users.Domain;

namespace Users.Application.Abstractions.Messaging;

public interface ICommand { }

public interface ICommand<TResponse> { }

public interface ICommandHandler<TCommand>
where TCommand : ICommand
{
    Task<Result<bool>> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}

public interface ICommandHandler<TCommnad, TResponse>
where TCommnad : ICommand<TResponse>
{
    Task<Result<TResponse>> HandleAsync(TCommnad commnad, CancellationToken cancellationToken = default);
}
