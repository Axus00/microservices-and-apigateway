using Users.Domain;

namespace Users.Application.Abstractions;
public interface IRepository<T>
{
    Task<List<Result<T>>> GetAll();
    Task<Result<T>> GetById(Guid id);
    Task<Result<T>> CreateUser();
    Task<Result<T>> UpdateUser(Guid id);
    Task<Result<T>> DeleteUser(Guid id);
}
