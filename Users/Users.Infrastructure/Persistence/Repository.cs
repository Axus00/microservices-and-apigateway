using Microsoft.EntityFrameworkCore;
using Users.Application.Abstractions;
using Users.Domain;
using Users.Infrastructure.Database;

namespace Users.Infrastructure.Persistence;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<TEntity> _dbSet;
    protected Repository(
        ApplicationDbContext context
    )
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }
    public async Task<Result<TEntity>> CreateAsync<TDto>(TDto dto, Func<TDto, TEntity> map)
    {
        if (dto == null)
            return Result<TEntity>.Failure("El mapeo no puede ser nulo");

        var entity = map(dto);
        _context.Set<TEntity>().Add(entity);

        await _context.SaveChangesAsync();
        return Result<TEntity>.Success(entity, "Seha creado de manera exitosa");
    }

    public async Task<Result<TEntity>> DeleteAsync(Guid id)
    {
        var searchEntity = await _context.Set<TEntity>().FindAsync(id);
        if (searchEntity is null)
            return Result<TEntity>.Failure("No ha sido posible encontrar el recurso");

        _context.Set<TEntity>().Remove(searchEntity);
        await _context.SaveChangesAsync();

        return Result<TEntity>.Success(searchEntity, "Ha sido eliminado de manera correcta");
    }

    public async Task<Result<List<TEntity>>> GetAllAsync()
    {
        var query = await _dbSet.ToListAsync();
        return Result<List<TEntity>>.Success(query, "Operación realizada con éxito");
    }

    public async Task<Result<TEntity>> GetByIdAsync(Guid id)
    {
        var query = await _dbSet.FindAsync(id);
        if (query == null)
            return Result<TEntity>.Failure("No ha sido posible encontrar la entidad");

        return Result<TEntity>.Success(query, "Operación realizada con éxito"); 
    }

    public async Task<Result<TEntity>> UpdateAsync(Guid id, TEntity entity)
    {
        var searchEntity = await _context.Set<TEntity>().FindAsync(id);
        if (searchEntity == null)
            return Result<TEntity>.Failure("No ha sido posible encontrarlo");

        _context.Entry(searchEntity).CurrentValues.SetValues(entity);
        await _context.SaveChangesAsync();

        return Result<TEntity>.Success(searchEntity, "Se ha actualizado de manera correcta");
    }
}
