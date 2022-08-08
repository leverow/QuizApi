using System.Security.Cryptography;
using System.Text;
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
    public (bool IsSuccess, Exception? exception, Topic topic) Create(Topic topic)
    {
        try
        {
            var entity = Mappers.ModelToEntity(topic);
            _unitOfWork.Topics.Add(entity);
            _unitOfWork.Save();
            _logger.LogInformation("✅ Topic was succuessfully created");
            return (true, null, topic);
        }
        catch(Exception e)
        {
            _logger.LogInformation($"❌ Error occured while creating new Topic");
            return (false, e, topic);
        }
    }

    public IEnumerable<Topic> GetAll()
    {
        var entities = _unitOfWork.Topics.GetAll();

        IEnumerable<Models.Topic> models = new List<Models.Topic>(){};
        
        models = entities.Select(Mappers.EntityToModel);
        
        return models;
    }

    public (bool IsSuccess, Exception? exception, Topic topic) GetById(ulong id)
    {
        try
        {
            var entity = _unitOfWork.Topics.GetById(id);
            var model = Mappers.EntityToModel(entity!);
            _logger.LogInformation("✅ Finding topic via id successfully completed");
            return (true, null, model);
        }
        catch(Exception e)
        {
            _logger.LogInformation($"🛑 Error occured while finding Topic via id");
            return (false, e, null!);
        }
    }

    public (bool IsSuccess, Exception? exception, IEnumerable<Models.Topic> topics) GetByName(string name)
    {
        try
        {
            var entities = _unitOfWork.Topics.Find(e => e.Name == name);
            var models = entities.Select(Mappers.EntityToModel);
            _logger.LogInformation("✅ Finding topic via name successfully completed");
            return (true, null, models);
        }
        catch(Exception e)
        {
            _logger.LogInformation($"🛑 Error occured while finding Topic via name");
            return (false, e, null!);
        }
    }
    public (bool IsSuccess, Exception? exception, Topic topic) Update(Topic topic)
    {
        try
        {
            var entity = Mappers.ModelToEntity(topic);
            _unitOfWork.Topics.Update(entity);
            _unitOfWork.Save();
            _logger.LogInformation($"✅ Topic named {entity.Name} has been successfully updated");
            return (true, null, topic);
        }
        catch(Exception e)
        {
            _logger.LogInformation($"🛑 Error occured while updating Topic");
            return (false, e, topic);
        }
    }

    public (bool IsSuccess, Exception? exception, Topic topic) Remove(Topic topic)
    {
        try
        {
            var entity = Mappers.ModelToEntity(topic);
            _unitOfWork.Topics.Remove(entity);
            _unitOfWork.Save();
            _logger.LogInformation($"✅ Topic named {entity.Name} has been successfully deleted from DB");
            return (true, null, topic);
        }
        catch(Exception e)
        {
            _logger.LogInformation($"🛑 Error occured while removing Topic from DB");
            return (false, e, topic);
        }
    }

    public bool TopicExists(ulong id)
    {
        var result = _unitOfWork.Topics.Find(b => b.Id == id);
        
        if(result.Count() == 0) return false;

        return true;

    }

    public bool TopicExists(string name)
    {
        var nameHash = GenerateHash(name);
        var result = _unitOfWork.Topics.Find(b => b.NameHash == nameHash);
        
        if(result.Count() == 0) return false;

        return true;

    }

    public string? GenerateHash(string? stringToBeHashed)
    {
        using var sha256 = SHA256.Create();
        var nameBytes = Encoding.UTF8.GetBytes(stringToBeHashed 
            ?? throw new ArgumentNullException(nameof(stringToBeHashed)));
        var hashBytes = sha256.ComputeHash(nameBytes);

        var result = Encoding.UTF8.GetString(hashBytes);

        return(result);
    }


}