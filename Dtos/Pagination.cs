using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace QuizApi.Dtos;

public class Pagination
{
    [FromQuery, Range(1, int.MaxValue)]
    public int Page {get;set;} = 1;

    [FromQuery, Range(1, int.MaxValue)]
    public int Limit { get; set; } = 10;
    

}