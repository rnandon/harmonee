using harmonee.Server.Data;
using harmonee.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace harmonee.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyEventController : ControllerBase
    {
        private readonly IFamilyEventRepository _repository;

        public FamilyEventController(IFamilyEventRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public FamilyEvent? Get([FromRoute] Guid id)
        {
            return _repository.GetById(id);
        }

        [HttpPost]
        public IEnumerable<FamilyEvent> GetMany([FromBody] IEnumerable<Guid> ids)
        {
            return _repository.GetMany(ids);
        }

        [HttpGet("ByFamily/{familyId}")] 
        public IEnumerable<FamilyEvent> GetByFamily(Guid familyId)
        {
            return _repository.GetByFamily(familyId);
        }

        [HttpPost]
        public bool Create([FromBody] FamilyEvent familyEvent)
        {
            if (!familyEvent.IsValid(out var errors))
            {
                BadRequest(errors);
            }

            return _repository.Add(familyEvent);
        }

        [HttpPut]
        public bool Update([FromBody] FamilyEvent familyEvent)
        {
            if (!familyEvent.IsValid(out var errors, true))
            {
                BadRequest(errors);
            }

            return _repository.Update(familyEvent);
        }

        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            return _repository.Delete(id);
        }
    }
}
