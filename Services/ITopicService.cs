namespace QuizApi.Services;

public interface ITopicService
{
    IEnumerable<Models.Topic> GetAll();
    ValueTask<Models.Topic> GetByIdAsync(ulong id);
    ValueTask<Models.Topic> GetByNameAsync(string name);
    ValueTask<Models.Topic> RemoveAsync(Models.Topic topic);
    Task<(bool IsSuccess, Exception? exception, Models.Topic topic)> CreateAsync(Models.Topic topic);
    ValueTask<Models.Topic> UpdateAsync(Models.Topic topic);
}