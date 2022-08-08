namespace QuizApi.Services;

public interface ITopicService
{
    (bool IsSuccess, Exception? exception, Models.Topic topic) Create(Models.Topic topic);
    IEnumerable<Models.Topic> GetAll();
    (bool IsSuccess, Exception? exception, Models.Topic topic) GetById(ulong id);
    (bool IsSuccess, Exception? exception, IEnumerable<Models.Topic>) GetByName(string name);
    (bool IsSuccess, Exception? exception, Models.Topic topic) Update(Models.Topic topic);
    (bool IsSuccess, Exception? exception, Models.Topic topic) Remove(Models.Topic topic);

    bool TopicExists(ulong id);
}