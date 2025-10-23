using Microsoft.Extensions.DependencyInjection;
using Users.Domain;

namespace Users.Application.Abstractions.Messaging;

public interface IMediator
{
    Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken) where TCommand : ICommand;
    Task<Result<TResult>> SendAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken) where TQuery : IQuery<TResult>;
}

public class Mediator(IServiceProvider provider) : IMediator
{
    public async Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken) where TCommand : ICommand
    {
        var handler = provider.GetService<ICommandHandler<TCommand>>();
        await handler!.HandleAsync(command, cancellationToken);
    }

    public async Task<Result<TResult>> SendAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken) where TQuery : IQuery<TResult>
    {
        var handler = provider.GetService<IQueryHandler<TQuery, TResult>>();
        return await handler!.HandleAsync(query, cancellationToken);
    }
}