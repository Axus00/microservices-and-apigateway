using Users.Application.Abstractions;
using Users.Domain.Entities;
using Users.Infrastructure.Database;

namespace Users.Infrastructure.Persistence;
public class ProductRepository(ApplicationDbContext context) : Repository<Product>(context), IProductRepository
{
    
}
