namespace QuizApi.Dtos.Topic;

public class Topic
{

    public ulong Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Difficulty { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    
    [Obsolete("This constructor is only used by EF Core",true)]
    public Topic(){}

    public Topic(ulong id, string? name, string? description, string? difficulty, DateTimeOffset createdAt, DateTimeOffset updatedAt)
    {
        Id = id;
        Name = name;
        Description = description;
        Difficulty = difficulty;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}