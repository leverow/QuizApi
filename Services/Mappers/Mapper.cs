using QuizApi.Dtos.Topic;

namespace QuizApi.Services;

public class Mappers
{
    public static Models.Topic EntityToModel(Entities.Topic entity)
    => new(
        entity.Id,
        entity.CreatedAt,
        entity.UpdatedAt,
        entity.Name!,
        entity.Description!,
        entity.Difficulty switch
        {
            Entities.Enums.ETopicDifficulty.Beginner => Models.Enums.ETopicDifficulty.Beginner,
            Entities.Enums.ETopicDifficulty.Intermediate => Models.Enums.ETopicDifficulty.Intermediate,
            _ => Models.Enums.ETopicDifficulty.Advanced,
        });

    public static Models.Topic DtoToModel(CreateTopicDto dtoModel)
    {

        var model = new Models.Topic(
            name: dtoModel.Name!,
            description: dtoModel.Description!,
            difficulty: dtoModel.Difficulty switch
            {
                Dtos.Topic.ETopicDifficulty.Beginner => Models.Enums.ETopicDifficulty.Beginner,
                Dtos.Topic.ETopicDifficulty.Intermediate => Models.Enums.ETopicDifficulty.Intermediate,
                _ => Models.Enums.ETopicDifficulty.Advanced
            }
        );
        return model;
    }

    public static Models.Topic UpdateDtoToModel(UpdateTopicDto dtoModel)
    {

        var model = new Models.Topic(
            name: dtoModel.Name!,
            description: dtoModel.Description!,
            difficulty: dtoModel.Difficulty switch
            {
                Dtos.Topic.ETopicDifficulty.Beginner => Models.Enums.ETopicDifficulty.Beginner,
                Dtos.Topic.ETopicDifficulty.Intermediate => Models.Enums.ETopicDifficulty.Intermediate,
                _ => Models.Enums.ETopicDifficulty.Advanced
            }
        );
        return model;
    }

    public static Topic ModelToDto(Models.Topic model)
    {
        var dtoModel = new Topic(){
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            Difficulty = model.Difficulty.ToString(),
            CreatedAt = model.CreatedAt,
            UpdatedAt = model.UpdatedAt
        };
        return dtoModel;
    }

    public static Entities.Topic ModelToEntity(Models.Topic model)
    {
        var entity = new Entities.Topic(
            id: model.Id,
            createdAt: model.CreatedAt,
            updatedAt: model.UpdatedAt,
            name: model.Name ?? "hechnimayoqnom",
            description: model.Description ?? "hechnimayoqdescription",
            difficulty: model.Difficulty switch
            {
                Models.Enums.ETopicDifficulty.Beginner => Entities.Enums.ETopicDifficulty.Beginner,
                Models.Enums.ETopicDifficulty.Intermediate => Entities.Enums.ETopicDifficulty.Intermediate,
                _ => Entities.Enums.ETopicDifficulty.Advanced
            }
        );
        return entity;
    }
}