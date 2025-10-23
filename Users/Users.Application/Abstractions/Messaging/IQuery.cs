using Users.Domain;

namespace Users.Application.Abstractions.Messaging;

public interface IQuery<TResult> { }

public interface IQueryHandler<TQuery, TResult>
where TQuery : IQuery<TResult>
{
    Task<Result<TResult>> HandleAsync(TQuery query, CancellationToken cancellationToken = default);
}
