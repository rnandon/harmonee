using Harmonee.API.Data;
using Harmonee.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Harmonee.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CalendarController : ControllerBase
{
    private readonly CalendarEventRepository _repository;

    public CalendarController (CalendarEventRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("{id:guid}")]
    public ActionResult<Group> Get(Guid id)
    {
        var result = _repository.Get(id);
        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    public ActionResult<CalendarEvent[]> GetMany([FromBody] IEnumerable<Guid> ids)
    {
        var result = _repository.Get(ids);
        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    public ActionResult<bool> Post([FromBody] CalendarEvent group)
    {
        var result = _repository.Create(group);
        if (!result)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpPut]
    public ActionResult<bool> Put([FromBody] CalendarEvent calendarEvent)
    {
        var result = _repository.Update(calendarEvent);
        if (!result)
        {
            BadRequest(result);
        }

        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public ActionResult Delete(Guid id)
    {
        var result = _repository.Delete(id);
        if (result)
        {
            return NoContent();
        }

        return NotFound();
    }
}
