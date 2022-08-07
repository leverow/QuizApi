using QuizApi.Entities.Enums;

namespace QuizApi.Entities;

public class Topic : EntityBase
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public ETopicDifficulty Difficulty { get; set; }
    
    [Obsolete("This constructor only be used from EF CORE", true)]
    public Topic(){}

    public Topic(
        ulong id,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt,
        string name,
        string description,
        ETopicDifficulty difficulty)
    {
        Id = id;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        Name = name;
        Description = description;
        Difficulty = difficulty;
    }
}