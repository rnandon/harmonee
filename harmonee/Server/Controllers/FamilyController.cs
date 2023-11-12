using harmonee.Server.Data;
using harmonee.Shared.Data;
using harmonee.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace harmonee.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyController : ControllerBase
    {
        private readonly IFamilyRepository _familyRepository;

        public FamilyController(IFamilyRepository familyRepository)
        {
            _familyRepository = familyRepository;
        }

        [HttpGet("{id}")]
        public Family GetFamily(Guid id)
        {
            var family = _familyRepository.GetById(id);
            if (family is null)
            {
                NotFound();
            }

            return family;
        }

        [HttpPost]
        public Family? CreateNewFamily([FromBody] Family model)
        {
            if (!model.IsValid(out var errors))
            {
                BadRequest(errors);
            }

            return _familyRepository.Add(model);
        }

        [HttpPut]
        public bool UpdateFamily([FromBody] Family model)
        {
            if (!model.IsValid(out var errors))
            {
                BadRequest(errors);
            }

            return _familyRepository.Update(model);
        }

        [HttpDelete]
        public bool DeleteFamily(Guid id) 
        {
            return _familyRepository.Delete(id);
        }
    }
}
