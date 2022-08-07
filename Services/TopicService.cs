using QuizApi.Models;

namespace QuizApi.Services;

public class TopicService : ITopicService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<TopicService> _logger;

    public TopicService(
        IUnitOfWork unitOfWork,
        ILogger<TopicService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
    public async Task<(bool IsSuccess, Exception? exception, Topic topic)> CreateAsync(Topic topic)
    {
        try
        {
            var entity = Mappers.ModelToEntity(topic);

            await _unitOfWork.Topics.Add(entity);

            _unitOfWork.Save();

            _logger.LogInformation("✅ Topic was succuessfully created");

            return (true, null, topic);
        }
        catch(Exception e)
        {
            _logger.LogInformation($"❌ Error occured while creating new Topic. Reason: {e.InnerException}");
            return (false, e, topic);
        }
    }

    public IEnumerable<Topic> GetAll()
    {
        var entities = _unitOfWork.Topics.GetAll();

        IEnumerable<Models.Topic> models = new List<Models.Topic>(){};
        
        foreach(var entity in entities)
        {
            var modelgaaylanganholati = Mappers.EntityToModel(entity);
            models.ToList().Add(modelgaaylanganholati);
        }
        
        return models;
    }

    public ValueTask<Topic> GetByIdAsync(ulong id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Topic> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Topic> RemoveAsync(Topic topic)
    {
        throw new NotImplementedException();
    }

    public ValueTask<Topic> UpdateAsync(Topic topic)
    {
        throw new NotImplementedException();
    }
}