
using QuizApi.Data;
using QuizApi.Entities;
using QuizApi.Repositories;

namespace quizz.Repositories;

public class TopicRepository : GenericRepository<Topic>, ITopicRepository
{
    public TopicRepository(AppDbContext context)
        : base(context) { }
}