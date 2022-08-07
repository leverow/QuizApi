namespace QuizApi.Entities;

public abstract class EntityBase
{
    public ulong Id { get; set; }   
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}