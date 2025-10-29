using Users.Application.Abstractions;
using Users.Domain.Entities;
using Users.Infrastructure.Database;

namespace Users.Infrastructure.Persistence;
public class UserRepository(ApplicationDbContext context) : Repository<User>(context), IUserRepository
{ }
