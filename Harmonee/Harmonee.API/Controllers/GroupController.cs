using Harmonee.API.Data;
using Harmonee.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Harmonee.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GroupController : ControllerBase
{
    private readonly GroupRepository _repository;

    public GroupController(GroupRepository repository)
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
    public ActionResult<Group[]> GetMany([FromBody] IEnumerable<Guid> ids)
    {
        var result = _repository.Get(ids);
        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    public ActionResult<bool> Post([FromBody] Group group)
    {
        var result = _repository.Create(group);
        if (!result)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpPut]
    public ActionResult<bool> Put([FromBody] Group group)
    {
        var result = _repository.Update(group);
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
