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

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult PostTopic(CreateTopicDto dtoModel)
    {
        if(!ModelState.IsValid) return NotFound();

        var model = Mappers.DtoToModel(dtoModel);

        var result = _service.Create(model);

        if(!result.IsSuccess)
        {
            _logger.LogInformation($" 🛑 Reason of 📧 exception is {result.exception?.Message}");
            return BadRequest();
        }

        return Created("/", dtoModel);
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

    [HttpGet("{id}")]
    public IActionResult GetTopicById([FromRoute]ulong id)
    {
        if(!_service.TopicExists(id)) return NotFound("Topic not found");
        
        var result = _service.GetById(id);
        if(!result.IsSuccess)
        {
            _logger.LogInformation($" 🛑 Reason of 📧 exception is {result.exception?.Message}");
            return BadRequest();
        }
        return Ok(result.topic);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTopic([FromRoute]ulong id, [FromForm]UpdateTopicDto dtoModel)
    {
        if(!_service.TopicExists(id)) return NotFound("Topic not found");
        
        var model = Mappers.UpdateDtoToModel(dtoModel);
        var result = _service.Update(model);
        if(!result.IsSuccess)
        {
            _logger.LogInformation($" 🛑 Reason of 📧 exception is {result.exception?.Message}");
            return BadRequest();
        }
        return Accepted(result.topic);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTopic([FromQuery]ulong id)
    {
        if(!_service.TopicExists(id)) return NotFound("Topic not found");

        var model = _service.GetById(id);
        var result = _service.Remove(model.topic);
        if(!result.IsSuccess)
        {
            _logger.LogInformation($" 🛑 Reason of 📧 exception is {result.exception?.Message}");
            return BadRequest();
        }
        return Accepted(result.topic);
    }
}