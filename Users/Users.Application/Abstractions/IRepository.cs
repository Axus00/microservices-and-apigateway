using Users.Domain;

namespace Users.Application.Abstractions;
public interface IRepository<T>
{
    Task<Result<List<T>>> GetAllAsync();
    Task<Result<T>> GetByIdAsync(Guid id);
    Task<Result<T>> CreateAsync<TDto>(TDto dto, Func<TDto, T> map);
    Task<Result<T>> UpdateAsync(Guid id, T entity);
    Task<Result<T>> DeleteAsync(Guid id);
}
