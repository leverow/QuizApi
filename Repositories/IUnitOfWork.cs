using quizz.Repositories;

public interface IUnitOfWork : IDisposable
{
    ITopicRepository Topics { get; }
    int Save();
}