
using Microsoft.EntityFrameworkCore;
using QuizApi.Data;
using QuizApi.Entities;

namespace quizz.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public ITopicRepository Topics { get; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Topics = new TopicRepository(context);

    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public int Save()
    {
        SetDates();
        return _context.SaveChanges();
    }

    private void SetDates()
    {
        foreach(var entry in _context.ChangeTracker.Entries<EntityBase>())
        {
            if(entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTimeOffset.UtcNow;
                entry.Entity.UpdatedAt = DateTimeOffset.UtcNow;
            }

            if(entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTimeOffset.UtcNow;
            }
        }
    }
}