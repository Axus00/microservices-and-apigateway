using Users.Application.Abstractions;
using Users.Domain;

namespace Users.Infrastructure.Persistence;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    public Task<Result<TEntity>> CreateUser()
    {
        throw new NotImplementedException();
    }

    public Task<Result<TEntity>> DeleteUser(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Result<TEntity>>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Result<TEntity>> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result<TEntity>> UpdateUser(Guid id)
    {
        throw new NotImplementedException();
    }
}
