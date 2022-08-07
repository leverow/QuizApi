using QuizApi.Models.Enums;

namespace QuizApi.Models;

public class Topic
{
    public ulong Id { get; set; }   
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public string? Name { get; set; }
    // public string? NameHash{ get; set; }
    public string? Description { get; set; }
    public ETopicDifficulty Difficulty { get; set; }
    
    [Obsolete("This constructor only be used from EF CORE", true)]
    public Topic(){}

    public Topic(
        string name,
        string description,
        ETopicDifficulty difficulty)
    {
        Name = name;
        Description = description;
        Difficulty = difficulty;
    }
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