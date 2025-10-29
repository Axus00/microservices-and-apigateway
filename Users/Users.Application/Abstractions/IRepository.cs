using Users.Domain;

namespace Users.Application.Abstractions;
public interface IRepository<T>
{
    Task<Result<List<T>>> GetAll();
    Task<Result<T>> GetById(Guid id);
    Task<Result<T>> CreateUser<TDto>(TDto dto, Func<TDto, T> map);
    Task<Result<T>> UpdateUser(Guid id, T entity);
    Task<Result<T>> DeleteUser(Guid id);
}
