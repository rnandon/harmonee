using harmonee.ApiService.Repositories;
using harmonee.Shared.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace harmonee.ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GroupController : ControllerBase
{
    private readonly IGroupRepository _repository;

    public GroupController(IGroupRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        var group = _repository.Get(id);
        if (group is null)
        {
            return NotFound();
        }

        return Ok(group);
    }

    // GET: api/<GroupController>
    [HttpPost]
    public IActionResult Get(IEnumerable<Guid> ids)
    {
        return Ok(_repository.Get(ids));
    }

    // GET api/<GroupController>/5

    // POST api/<GroupController>
    [HttpPost]
    public IActionResult Post([FromBody] Group group)
    {
        if (!group.IsValid())
        {
            return BadRequest();
        }
        var result = _repository.Add(group);
        return result ? Ok(result) : UnprocessableEntity();
    }

    // PUT api/<GroupController>/5
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Group group)
    {
        if (id != group.Id || !group.IsValid())
        {
            return BadRequest();
        }

        return _repository.Update(group) ? Ok(group) : UnprocessableEntity();
    }

    // DELETE api/<GroupController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id, [FromBody] Group group)
    {
        if (id != group.Id)
        {
            return BadRequest();
        }

        return _repository.Remove(group) ? NoContent() : BadRequest();
    }
}
