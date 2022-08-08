using System.Linq.Expressions;
using QuizApi.Data;

namespace QuizApi.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly AppDbContext _context;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }

    public async ValueTask<TEntity> Add(TEntity entity)
    {
        var entry = await _context.Set<TEntity>().AddAsync(entity);
        // await _context.SaveChangesAsync();
        return entry.Entity;
    }

    public async void AddRange(IEnumerable<TEntity> entities)
        => await _context.Set<TEntity>().AddRangeAsync(entities);

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        => _context.Set<TEntity>().Where(expression);

    public IEnumerable<TEntity> GetAll()
        => _context.Set<TEntity>().ToList();

    public TEntity? GetById(ulong id)
        => _context.Set<TEntity>().Find(id);

    public TEntity Remove(TEntity entity)
    {
        var entry = _context.Set<TEntity>().Remove(entity);
        return entry.Entity;
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
        => _context.Set<TEntity>().RemoveRange(entities);

    public TEntity Update(TEntity entity)
    {
        var entry = _context.Set<TEntity>().Update(entity);
        return entry.Entity;
    }
}