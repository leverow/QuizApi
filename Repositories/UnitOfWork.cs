
using System.Security.Cryptography;
using System.Text;
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
        AddNameHash();
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

    private void AddNameHash()
    {
        foreach(var entry in _context.ChangeTracker.Entries<Topic>())
        {
            if(entry.Entity is Topic topic)
            {
                using var sha256 = SHA256.Create();
                var nameBytes = Encoding.UTF8.GetBytes(topic.Name 
                    ?? throw new ArgumentNullException(nameof(topic.Name)));
                var hashBytes = sha256.ComputeHash(nameBytes);

                topic.NameHash = Encoding.UTF8.GetString(hashBytes);
            }
        }
    }
}