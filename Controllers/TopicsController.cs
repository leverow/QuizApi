using Microsoft.AspNetCore.Mvc;
using QuizApi.Dtos;
using QuizApi.Dtos.Topic;
using QuizApi.Services;

namespace QuizApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class TopicsController : ControllerBase
{
    private readonly ILogger<TopicsController> _logger;
    private readonly ITopicService _service;

    public TopicsController(
        ILogger<TopicsController> logger,
        ITopicService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseBase<List<Topic>>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GetTopics([FromQuery]Pagination pagination)
    {
        var dtoModels = _service.GetAll()
            .Skip((pagination.Page - 1) * pagination.Limit)
            .Take(pagination.Limit)
            .Select(Mappers.ModelToDto)
            .ToList();

        var response =  new ResponseBase<List<Topic>>()
        {
            Data = dtoModels,
            Pagination = pagination
        };

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PostTopic(CreateTopicDto model)
    {
        if(!ModelState.IsValid) return NotFound();

        var ModelgaAylanganDto = Mappers.DtoToModel(model);

        var result = await _service.CreateAsync(ModelgaAylanganDto);
        // Console.WriteLine($"Bu yerda malumot qoshilishi mumkin edi : {ModelgaAylanganDto}");
        

        if(!result.IsSuccess)
        {
            _logger.LogInformation($"Error boldi sababi: {result.exception?.Message}");
            return BadRequest();
        }
        // var entity = ToEntity(model);

        // var result = await _unitOfWork.Topics.Add(entity);
        // _unitOfWork.Save();


        return Created("/", model);
    }
}