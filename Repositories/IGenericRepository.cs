using System.Linq.Expressions;

namespace QuizApi.Repositories;

public interface IGenericRepository<TEntity> where TEntity : class
{
    TEntity? GetById(ulong id);
    IEnumerable<TEntity> GetAll();
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
    ValueTask<TEntity> Add(TEntity entity);
    void AddRange(IEnumerable<TEntity> entities);
    TEntity Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
    TEntity Update(TEntity entity);

}