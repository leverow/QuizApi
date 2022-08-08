using System.ComponentModel.DataAnnotations;

namespace QuizApi.Dtos.Topic;

public class UpdateTopicDto
{
    [Required, MaxLength(50)]
    public string? Name { get; set; }

    [Required, MaxLength(255)]
    public string? Description { get; set; }
    public ETopicDifficulty Difficulty { get; set; }
    
    
}