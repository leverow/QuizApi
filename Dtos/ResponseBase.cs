namespace QuizApi.Dtos;

public class ResponseBase<TData> where TData : class
{
    public Pagination? Pagination {get; set;}
    public Error? Error { get; set; }
    public TData? Data { get; set; }
    
    
}